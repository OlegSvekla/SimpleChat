using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Core.Dtos
{
    public class BaseEntityDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
    }
}
