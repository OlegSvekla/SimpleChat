﻿using SimpleChat.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleChat.Core.Dtos
{
    public class UserDto : BaseEntityDto
    {
        public string Name { get; set; }
    }
}