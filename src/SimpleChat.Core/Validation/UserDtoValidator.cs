using FluentValidation;
using SimpleChat.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Core.Validation
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(dto => dto.Name).NotNull()
                                    .NotEmpty()
                                    .WithMessage("Name is required");
        }
    }
}
