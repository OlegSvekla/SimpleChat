using SimpleChat.Api.Interfaces.Implementation.Repositories;
using SimpleChat.Core.Interfaces.IRepositories;

namespace SimpleChat.Api.Extensions
{
    public static class ServicesConfiguration
    {
        public static void Configuration(
            IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddSignalR();


            //services.AddScoped<IFilterService<PagedUserAndRoleResult>, UserService>();
            //services.AddScoped<IUserService<User>, UserService>();

            //services.AddScoped<IValidator<UserQueryParameters>, UserQueryParametersValidation>();
            //services.AddScoped<IValidator<UserDto>, UserDtoValidation>();
            //services.AddScoped<IValidator<RoleDto>, RoleDtoValidation>();

            //services.AddAutoMapper(typeof(MapperEntityToDto));
        }
    }
}
