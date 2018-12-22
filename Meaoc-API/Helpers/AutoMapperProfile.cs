using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;

namespace Meaoc_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}