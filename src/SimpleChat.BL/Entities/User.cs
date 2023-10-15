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

        public ICollection<ChatUser> ChatUsers { get; set; } // Связь с чатами, в которых участвует пользователь
    }
}
