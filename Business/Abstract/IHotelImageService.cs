using Business.Abstract.Base;
using Entities.Concrete;
using Entities.DTOs.Concrete.HotelDTO;

namespace Business.Abstract
{
    public interface IHotelImageService : IBaseService<Hotel, HotelAddDTO, HotelDeleteDTO, HotelUpdateDTO>
    {
    }
}