using AutoMapper;
using Entities.DTOs.Concrete.AuthDTO;
using Shared.Entities.Concrete;

namespace Business.AutoMapper
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserForRegisterDTO, User>().ReverseMap();
            CreateMap<UserForLoginDTO, User>().ReverseMap();
        }
    }
}