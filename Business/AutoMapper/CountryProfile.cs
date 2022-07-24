using AutoMapper;
using Entities.DTOs.Concrete.CountryDTO;
using Entities.Concrete.Info;

namespace Business.AutoMapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryAddDTO, Country>().ReverseMap();
            CreateMap<CountryUpdateDTO, Country>().ReverseMap();
        }
    }
}