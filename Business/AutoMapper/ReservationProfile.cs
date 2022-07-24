using AutoMapper;
using Entities.DTOs.Concrete.ReservationDTO;
using Entities.Concrete;

namespace Business.AutoMapper
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationAddDTO, Reservation>().ReverseMap();
            CreateMap<ReservationUpdateDTO, Reservation>().ReverseMap();
        }
    }
}