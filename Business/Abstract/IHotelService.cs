using Business.Abstract.Base;
using Entities.Concrete;
using Entities.DTOs.Concrete.HotelDTO;

namespace Business.Abstract
{
    public interface IHotelService : IBaseService<Hotel,HotelAddDTO,HotelDeleteDTO,HotelUpdateDTO>
    {
    }
}