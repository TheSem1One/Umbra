using Umbra.Domain.Common;

namespace Umbra.Domain.Entities
{
    public class Chat : BaseEntity
    {
        public string? Name { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();

        public Guid CreatorId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<User> Chatters { get; set; } = new List<User>();
    }
}
