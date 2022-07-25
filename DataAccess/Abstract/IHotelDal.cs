using Core.Entities;
using Entities.Concrete;
using Entities.DTOs.Concrete.HotelDTO;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IHotelDal: IEntityRepository<Hotel>
    {
        List<HotelDetailDTO> GetHotelDetails(Expression<Func<HotelDetailDTO, bool>> filter = null);
    }
}