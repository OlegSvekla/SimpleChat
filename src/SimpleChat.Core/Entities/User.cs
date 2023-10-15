using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BL.Entities
{
    public class User 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ChatUser> ChatUsers { get; set; } // Связь с чатами, в которых участвует пользователь
        public List<Message> Messages { get; set; }
        public List<Chat> CreatedChats { get; set; } // Связь с чатами, созданными пользователем
    }
}
