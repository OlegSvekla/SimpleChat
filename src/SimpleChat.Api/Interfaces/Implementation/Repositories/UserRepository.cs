using SimpleChat.BL.Entities;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Infrastructure.Data;

namespace SimpleChat.Api.Interfaces.Implementation.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
