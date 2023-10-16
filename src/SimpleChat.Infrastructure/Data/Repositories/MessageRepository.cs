using SimpleChat.Core.Entities;
using SimpleChat.Core.Interfaces.IRepositories;

namespace SimpleChat.Infrastructure.Data.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
