using SimpleChat.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleChat.Core.Dtos
{
    public class MessageDto : BaseEntityDto
    {
        public string Content { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

        [JsonIgnore]
        public int ChatId { get; set; }
        public ChatDto Chat { get; set; }
    }
}
