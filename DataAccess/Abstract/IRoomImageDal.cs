using Core.Entities;
using Entities.Concrete.Image;

namespace DataAccess.Abstract
{
    public interface IRoomImageDal:IEntityRepository<RoomImage>
    {
        public bool IsExist(int id);
    }
}