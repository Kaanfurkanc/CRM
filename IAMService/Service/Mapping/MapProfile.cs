using Amazon.Runtime.Internal.Util;
using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<User, NewUserDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
        }
    }
}
