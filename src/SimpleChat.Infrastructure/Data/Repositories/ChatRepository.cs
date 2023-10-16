using SimpleChat.BL.Entities;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Infrastructure.Data;
using SimpleChat.Infrastructure.Data.Repositories;

namespace SimpleChat.Infrastructure.Data.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
