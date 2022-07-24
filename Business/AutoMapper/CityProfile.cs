using AutoMapper;
using Entities.DTOs.Concrete.CityDTO;
using Entities.Concrete.Info;

namespace Business.AutoMapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityAddDTO, City>().ReverseMap();
            CreateMap<CityUpdateDTO, City>().ReverseMap();
        }
    }
}