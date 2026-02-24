using Umbra.Domain.Common;

namespace Umbra.Domain.Entities
{
    public class File : BaseEntity ,ISoftDeletableEntity
    {
        public string FileName { get; set; } = default!;

        public Guid LatestBlobId { get; set; }

        public Blob LatestBlob { get; set; } = default!;

        public Guid CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? DeletedAtUtc { get; set; }

        public ICollection<FileVersion> Versions { get; set; } = new List<FileVersion>();
    }
}
