using SimpleChat.BL.Entities;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Infrastructure.Data;

namespace SimpleChat.Api.Interfaces.Implementation.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
