using Umbra.Domain.Common;
using Umbra.Domain.Enums;

namespace Umbra.Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public Guid FileId { get; set; }

        public File File { get; set; } = default!;

        public AttachmentOwnerType OwnerType { get; set; }

        public Guid OwnerId { get; set; }

        public AttachmentPurpose Purpose { get; set; }

        public int? SortOrder { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}
