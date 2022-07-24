using Core.Entities;
using Entities.Concrete.Image;

namespace DataAccess.Abstract
{
    public interface IHotelImageDal:IEntityRepository<HotelImage>
    {
        public bool IsExist(int id);
    }
}