using SimpleChat.Core.Entities;

namespace SimpleChat.BL.Entities
{
    public class Chat : BaseEntity
    {
        public string ChatName { get; set; }

        public List<ChatUser> ChatUsers { get; set; }
        public List<Message> Messages { get; set; }

        public int UserCreatorId { get; set; }
        public User UserCreator { get; set; }
    }
}
