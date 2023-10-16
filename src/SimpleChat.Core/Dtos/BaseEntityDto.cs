using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleChat.Core.Dtos
{
    public abstract class BaseEntityDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
    }
}
