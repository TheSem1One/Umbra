# Domain Model: Users, Chats, Messages & Attachments

Цей документ описує **доменні сутності** системи обміну повідомленнями та автентифікації. Містить базові поля, звʼязки між сутностями, а також додаткові ідеї й розширення, які можуть бути корисними для реального продакшн‑використання.

---

## 1. User Entity

### Опис

Користувач системи. Може брати участь у чатах, надсилати повідомлення та мати роль (Admin/User).

### Структура

```ts
User {
  id: Guid;
  email: string;
  imageUrl?: string;
  passwordHash: string;
  fullName: string;
  role: UserRole; // Enum: Admin, User
  isActive: boolean;

  chats: Chat[];
}
```

### Додаткові рекомендації

* `email` — унікальний, індексований
* `isActive` — для soft‑disable акаунту без видалення
* `imageUrl` — може посилатись на Attachment з `ProfilePicture`

### Можливі розширення

* `lastLoginAtUtc: DateTimeOffset`
* `createdAtUtc: DateTimeOffset`
* `emailVerified: boolean`

---

## 2. Chat Entity

### Опис

Чат — це контейнер для обміну повідомленнями між двома або більше користувачами.

### Структура

```ts
Chat {
  id: Guid;
  chatName?: string;

  users: User[];
  messages: Message[];
}
```

### Бізнес‑правила

* Чат повинен мати **мінімум 2 користувачів**
* `chatName` може бути `null` для приватних (1‑to‑1) чатів

### Можливі розширення

* `isGroup: boolean`
* `createdAtUtc: DateTimeOffset`
* `createdBy: Guid`
* `lastMessageAtUtc: DateTimeOffset`

---

## 3. Message Entity

### Опис

Повідомлення, яке надсилається користувачем у межах чату. Може містити текст або файл.

### Структура

```ts
Message {
  id: Guid;

  senderId: Guid; // User
  chatId: Guid;   // Chat

  contentMessage?: string;
  contentFileUrl?: string;

  timestamp: DateTime;
}
```

### Бізнес‑правила

* Повідомлення **повинно мати хоча б один контент**:

  * `contentMessage` **або**
  * `contentFileUrl`
* `senderId` має належати користувачу, який є учасником чату

---

## 4. Attachment Entity

### Опис

Універсальна сутність для файлів, що використовуються в різних контекстах (чат, аватар користувача тощо).

### Структура

```ts
Attachment {
  id: Guid;

  fileUrl: string; // URL до файлу

  attachmentOwnerType: OwnerType;
  ownerId: Guid; // Chat або User

  attachmentPurpose: AttachmentPurpose;
  // Enum: ProfilePicture, ChatFile

  createdBy: Guid; // User
  createdAtUtc: DateTimeOffset;
}
```

### Enum‑и

```ts
OwnerType {
  User,
  Chat
}

AttachmentPurpose {
  ProfilePicture,
  ChatFile
}
```

### Бізнес‑правила

* `ProfilePicture` → `ownerId` має вказувати на `User`
* `ChatFile` → `ownerId` має вказувати на `Chat`
* `createdBy` — користувач, який завантажив файл


---

## 5. Звʼязки між сутностями

```text
User 1..* ─── *..1 Chat
Chat 1 ─── * Message
User 1 ─── * Message (sender)
User 1 ─── * Attachment
Chat 1 ─── * Attachment
```

---

## 6. Загальні архітектурні нотатки

* Всі `Guid` — генеруються на backend
* Рекомендується використовувати **soft delete** для User та Message
* Attachment зберігати окремо від Message (S3 / Blob Storage)
* Message не повинен напряму містити файл — лише URL / reference

---

## 7. Потенційні Edge Cases

* Видалений чат — повідомлення залишаються для аудиту
* Файл видалений зі storage, але Attachment існує → fallback UI

---

## 8. Що можна додати далі

* Read receipts (`MessageRead` entity)
* Typing indicators (real‑time, без БД)
* Chat roles (Owner / Moderator)
* Pinned messages
* Message reactions

---
