using AutoMapper;
using Meaoc_API.Domain.Dtos;
using Meaoc_API.Domain.Models;

namespace Meaoc_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UserLoggedInDto, User>();
            CreateMap<User, UserLoggedInDto>();
        }
    }
}