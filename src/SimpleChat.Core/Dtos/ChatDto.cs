using SimpleChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Core.Dtos
{
    public class ChatDto : BaseEntityDto
    {
        public string ChatName { get; set; }

        public int UserCreatorId { get; set; }
    }
}
