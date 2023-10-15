using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BL.Entities
{
    public class Chat : BaseEntitie
    {
        public string ChatName { get; set; }

        public List<ChatUser> ChatUsers { get; set; } // Связь с участниками чата
        public List<Message> Messages { get; set; } // Сообщения в чате

        public int CreatorUserId { get; set; } // Id пользователя, создавшего чат
        public User Creator { get; set; }
    }
}
