using SimpleChat.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Core.Dtos
{
    public class ChatUserDto
    {

        public UserDto User { get; set; }


        public ChatDto Chat { get; set; }
    }
}
