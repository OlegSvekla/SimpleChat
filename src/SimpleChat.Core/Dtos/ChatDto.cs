using SimpleChat.BL.Entities;
using SimpleChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleChat.Core.Dtos
{
    public class ChatDto : BaseEntityDto
    {
        public string ChatName { get; set; }

        public UserDto UserCreator { get; set; }
    }
}
