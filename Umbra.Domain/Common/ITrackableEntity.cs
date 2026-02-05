namespace Umbra.Domain.Common
{
    internal interface IHasCreatedAtUtc
    {
        public DateTimeOffset CreatedAtUtc { get; set; }
    }

    internal interface IHasUpdateAtUtc
    {
        public DateTimeOffset? UpdatedAtUtc { get; set; }
    }

    internal interface ITrackableEntity : IHasCreatedAtUtc, IHasUpdateAtUtc;
}
