using FluentNHibernate.Automapping;
using SimpleChat.BL.Entities;
using SimpleChat.Core.Dtos;

namespace SimpleChat.Infrastructure.Mapper
{
    public sealed class MapperEntityToDto : AutoMapper.Profile
    {
        public MapperEntityToDto()
        {
            CreateMap<Chat, ChatDto>().ReverseMap();
        }
    }
}