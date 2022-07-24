using Business.Abstract.Base;
using Entities.Concrete.Image;
using Entities.DTOs.Concrete.RoomImageDTO;

namespace Business.Abstract
{
    public interface IRoomImageService : IBaseImageService<RoomImage,
        RoomImageAddDTO, RoomImageDeleteDTO, RoomImageUpdateDTO>
    {
    }
}