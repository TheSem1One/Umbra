using Umbra.Domain.Common;
using Umbra.Domain.Enums;

namespace Umbra.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public UserRole Role { get; set; } = UserRole.User;

        public Rank Rank { get; set; } = Rank.Soldier;

        public bool IsActiveAccount { get; set; }

        public ICollection<Chat> Chats { get; set; } = new List<Chat>();
    }
}
