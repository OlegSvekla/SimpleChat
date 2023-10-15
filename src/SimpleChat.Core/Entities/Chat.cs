namespace SimpleChat.BL.Entities
{
    public class Chat 
    {
        public int Id { get; set; }

        public string ChatName { get; set; }

        public List<ChatUser> ChatUsers { get; set; } // Связь с участниками чата

        public List<Message> Messages { get; set; } // Сообщения в чате

        public int UserCreatorId { get; set; }
        public User UserCreator { get; set; }
    }
}
