using AutoMapper;
using Entities.DTOs.Concrete.RoomImageDTO;
using Entities.Concrete.Image;

namespace Business.AutoMapper
{
    public class RoomImageProfile : Profile
    {
        public RoomImageProfile()
        {
            CreateMap<RoomImageAddDTO, RoomImage>().ReverseMap();
            CreateMap<RoomImageUpdateDTO, RoomImage>().ReverseMap();
        }
    }
}