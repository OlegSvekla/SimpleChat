using SimpleChat.BL.Entities;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Infrastructure.Data;
using SimpleChat.Infrastructure.Data.Repositories;

namespace SimpleChat.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
