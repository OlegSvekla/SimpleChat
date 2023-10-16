using SimpleChat.Core.Dtos;
using SimpleChat.Core.Entities;

namespace SimpleChat.Infrastructure.Mapper
{
    public sealed class MapperEntityToDto : AutoMapper.Profile
    {
        public MapperEntityToDto()
        {
            CreateMap<Chat, ChatDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}