using SimpleChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public List<ChatUser> ChatUsers { get; set; }
        public List<Message> Messages { get; set; }
        public List<Chat> CreatedChats { get; set; }
    }
}
