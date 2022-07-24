using Business.Abstract.Base;
using Entities.Concrete;
using Entities.DTOs.Concrete.RoomDTO;

namespace Business.Abstract
{
    public interface IRoomService : IBaseService<Room, 
        RoomAddDTO, RoomDeleteDTO, RoomUpdateDTO>
    {
    }
}