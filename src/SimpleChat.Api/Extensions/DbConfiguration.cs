using Microsoft.EntityFrameworkCore;
using SimpleChat.Infrastructure.Data;

namespace SimpleChat.Api.Extensions
{
    public static class DbConfiguration
    {
        public static void Configuration(
            IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddDbContext<SimpleChatDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SimpleChatDbConnection")));
        }
    }
}
