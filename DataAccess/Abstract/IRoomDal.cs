using Core.Entities;
using Entities.Concrete;
using Entities.DTOs.Concrete.RoomDTO;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRoomDal: IEntityRepository<Room>
    {
        List<RoomDetailDTO> GetRoomDetails(Expression<Func<RoomDetailDTO, bool>> filter = null);
    }
}