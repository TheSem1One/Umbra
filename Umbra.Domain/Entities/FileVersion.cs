using Umbra.Domain.Common;

namespace Umbra.Domain.Entities
{
    public class FileVersion : BaseEntity, ITrackableEntity
    {
        public Guid FileId { get; set; }

        public File File { get; set; } = default!;

        public int Version { get; set; }

        public Guid BlobId { get; set; }

        public Blob Blob { get; set; } = default!;

        public Guid CreatedBy { get; set; }

        public string? ChangeNote { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }

        public DateTimeOffset? UpdatedAtUtc { get; set; }
    }
}
