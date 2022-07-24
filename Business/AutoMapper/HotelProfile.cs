using AutoMapper;
using Entities.DTOs.Concrete.HotelDTO;
using Entities.Concrete;

namespace Business.AutoMapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelAddDTO, Hotel>().ReverseMap();
            CreateMap<HotelUpdateDTO, Hotel>().ReverseMap();
        }
    }
}