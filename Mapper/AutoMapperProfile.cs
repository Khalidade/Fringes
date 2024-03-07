using AutoMapper;
using Fringes.Dtos;
using Fringes.Models;

namespace Fringes.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Message, CreateMessageDto>();
            CreateMap<CreateMessageDto, Message>();
            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}
