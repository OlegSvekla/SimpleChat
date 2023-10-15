using SimpleChat.Core.Interfaces.IServices;

namespace SimpleChat.Api.Interfaces.Implementation.Services
{
    public class ChatService : IChatService<ChatDto>
    {
        public Task<bool> AddChat(ChatDto book)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDto> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDto> GetChatByChatName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDto> GetChatById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDto> GetChatByUserCreatorId(int userCreatorId)
        {
            throw new NotImplementedException();
        }

    }
}
