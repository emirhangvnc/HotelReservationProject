using AutoMapper;
using Entities.DTOs.Concrete.UserDTO;
using Shared.Entities.Concrete;

namespace Business.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();
        }
    }
}