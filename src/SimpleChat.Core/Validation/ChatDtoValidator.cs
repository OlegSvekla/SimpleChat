using FluentValidation;
using SimpleChat.Core.Dtos;

namespace SimpleChat.Core.Validation
{
    public class ChatDtoValidator : AbstractValidator<ChatDto>
    {
        public ChatDtoValidator()
        {
            RuleFor(dto => dto.ChatName).NotNull()
                                        .NotEmpty()
                                        .WithMessage("ChatName is required");

            RuleFor(dto => dto.UserCreator).NotNull()
                                           .NotEmpty()
                                           .WithMessage("User must be set");
        }
    }
}
