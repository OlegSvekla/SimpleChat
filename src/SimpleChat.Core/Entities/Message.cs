using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.BL.Entities
{
    public class Message 
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; } // Пользователь, отправивший сообщение
        public User User { get; set; }

        public int ChatId { get; set; } // Чат, в котором было отправлено сообщение
        public Chat Chat { get; set; }
    }
}
