using AutoMapper;
using Entities.DTOs.Concrete.HotelImageDTO;
using Entities.Concrete.Image;

namespace Business.AutoMapper
{
    public class HotelImageProfile : Profile
    {
        public HotelImageProfile()
        {
            CreateMap<HotelImageAddDTO, HotelImage>().ReverseMap();
            CreateMap<HotelImageUpdateDTO, HotelImage>().ReverseMap();
        }
    }
}