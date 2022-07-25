using Business.Abstract.Base;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Concrete.HotelDTO;

namespace Business.Abstract
{
    public interface IHotelService : IBaseService<Hotel,
        HotelAddDTO,HotelDeleteDTO,HotelUpdateDTO>
    {
        IDataResult<List<HotelDetailDTO>> GetHotelDetails();
    }
}