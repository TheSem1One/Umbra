using Umbra.Domain.Common;

namespace Umbra.Domain.Entities
{
    public class Message : BaseEntity, ITrackableEntity
    {
        public Guid SenderId { get; set; }

        public Guid ChatId { get; set; }

        public Chat Chat { get; set; } = null!;

        public string? ContentMessage { get; set; } = string.Empty;

        public string? ContentFileUrl { get; set; } = string.Empty;

        public DateTimeOffset CreatedAtUtc { get; set; }

        public DateTimeOffset? UpdatedAtUtc { get; set; }
    }
}
