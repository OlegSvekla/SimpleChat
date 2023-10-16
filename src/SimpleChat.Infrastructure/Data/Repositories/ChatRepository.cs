using SimpleChat.Core.Entities;
using SimpleChat.Core.Interfaces.IRepositories;

namespace SimpleChat.Infrastructure.Data.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
