﻿using FluentValidation;
using SimpleChat.Api.Interfaces.Implementation.Repositories;
using SimpleChat.Api.Interfaces.Implementation.Services;
using SimpleChat.Core.Dtos;
using SimpleChat.Core.Interfaces.IRepositories;
using SimpleChat.Core.Interfaces.IServices;
using SimpleChat.Core.Validation;
using SimpleChat.Infrastructure.Mapper;

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

            services.AddScoped<IChatService<ChatDto>, ChatService>();

            services.AddScoped<IValidator<ChatDto>, ChatDtoValidator>();
            services.AddScoped<IValidator<UserDto>, UserDtoValidator>();

            services.AddAutoMapper(typeof(MapperEntityToDto));

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
