using Business.Abstract.Base;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Concrete.RoomDTO;

namespace Business.Abstract
{
    public interface IRoomService : IBaseService<Room, 
        RoomAddDTO, RoomDeleteDTO, RoomUpdateDTO>
    {
        IDataResult<List<RoomDetailDTO>> GetRoomDetails();
    }
}