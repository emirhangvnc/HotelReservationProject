using AutoMapper;
using Entities.DTOs.Concrete.RoomDTO;
using Entities.Concrete;

namespace Business.AutoMapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomAddDTO, Room>().ReverseMap();
            CreateMap<RoomUpdateDTO, Room>().ReverseMap();
        }
    }
}