using Umbra.Domain.Common;

namespace Umbra.Domain.Entities
{
    public class Blob : BaseEntity, ITrackableEntity
    {
        public long Size { get; set; }

        public string ContentType { get; set; } = "application/octet-stream";

        public string StorageKey { get; set; } = default!;

        public DateTimeOffset CreatedAtUtc { get; set; }

        public DateTimeOffset? UpdatedAtUtc { get; set; }
    }
}
