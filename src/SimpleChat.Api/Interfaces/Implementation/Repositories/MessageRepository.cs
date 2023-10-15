using SimpleChat.BL.Entities;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Infrastructure.Data;

namespace SimpleChat.Api.Interfaces.Implementation.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
