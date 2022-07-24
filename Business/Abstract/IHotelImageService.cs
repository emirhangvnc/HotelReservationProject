using Business.Abstract.Base;
using Entities.Concrete.Image;
using Entities.DTOs.Concrete.HotelImageDTO;

namespace Business.Abstract
{
    public interface IHotelImageService : IBaseImageService<HotelImage,
        HotelImageAddDTO, HotelImageDeleteDTO, HotelImageUpdateDTO>
    {
    }
}