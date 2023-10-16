using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleChat.Core.Dtos;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Core.Interfaces.IServices;
using SimpleChat.Core.Entities;

namespace SimpleChat.Api.Interfaces.Implementation.Services
{
    public class ChatService : IChatService<ChatDto>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ChatService> _logger;


        public ChatService(IChatRepository chatRepository,
            IMapper mapper,
            ILogger<ChatService> logger)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
            _logger = logger;
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



        public async Task<bool> AddChat(ChatDto chatDto)
        {

            var existingChat = await _chatRepository.GetOneByAsync(expression: u => u.ChatName == chatDto.ChatName);
            if (existingChat is not null)
            {
                return false;
            }

            var chat = _mapper.Map<Chat>(chatDto);


            var result = await _chatRepository.CreateAsync(chat);
            if (result is null)
            {
                return false;
            }

            return true;
        }

        public async Task<ChatDto> DeleteChat(int bookId, int currentUserId)
        {
            var chatToDelete = await _chatRepository.GetOneByAsync(expression: _ => _.Id.Equals(bookId));
            if (chatToDelete is null)
            {
                return null;
            }
            if (chatToDelete.UserCreatorId == currentUserId)
            {
                await _chatRepository.DeleteAsync(chatToDelete);
                var chatDeleted = _mapper.Map<ChatDto>(chatToDelete);
                return chatDeleted;
            }

            return null;
        }
    }
}
