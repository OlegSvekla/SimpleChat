using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BL.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string ChatName { get; set; }

        public ICollection<ChatUser> ChatUsers { get; set; } // Связь с участниками чата
        public ICollection<Message> Messages { get; set; } // Сообщения в чате
    }
}
