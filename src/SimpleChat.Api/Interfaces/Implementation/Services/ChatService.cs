using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SimpleChat.Core.Dtos;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Core.Interfaces.IServices;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SimpleChat.Api.Interfaces.Implementation.Services
{
    public class ChatService : IChatService<ChatDto>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ChatService> _logger;
        private readonly IValidator<ChatDto> _validator;

        public ChatService(IChatRepository chatRepository,
            IMapper mapper,
            ILogger<ChatService> logger,
            IValidator<ChatDto> validator)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        public async Task<ChatDto> GetChatById(int id)
        {
            var chat = await _chatRepository
                      .GetOneByAsync(expression: _ => _.Id.Equals(id), include: query => query
                          .Include(chat => chat.UserCreator)
                      );

            if (chat is null)
            {
                return null;
            }

            return _mapper.Map<ChatDto>(chat);
        }

        public async Task<ChatDto> GetChatByChatName(string name)
        {
            var chat = await _chatRepository.GetOneByAsync(expression: _ => _.ChatName.Equals(name), include: query => query
              .Include(chat => chat.UserCreator)
          );

            if (chat is null)
            {
                return null;
            }

            return _mapper.Map<ChatDto>(chat);
        }

        public async Task<ChatDto> GetChatByUserCreatorId(int userCreatorId)
        {
            var chat = await _chatRepository
          .GetOneByAsync(expression: _ => _.UserCreatorId.Equals(userCreatorId)
          );

            if (chat is null)
            {
                return null;
            }

            return _mapper.Map<ChatDto>(chat);
        }

        public Task<bool> AddChat(ChatDto book)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDto> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }







    }
}
