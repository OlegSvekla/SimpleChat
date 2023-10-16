using SimpleChat.BL.Entities;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Infrastructure.Data;
using SimpleChat.Infrastructure.Data.Repositories;

namespace SimpleChat.Infrastructure.Data.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
