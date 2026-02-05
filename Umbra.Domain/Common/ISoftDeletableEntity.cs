namespace Umbra.Domain.Common
{
    public interface ISoftDeletableEntity
    {
        public DateTimeOffset? DeletedAtUtc { get; set; }
    }
}
