using Core.Entities;

namespace Entities.DTOs.Concrete.RoomImageDTO
{
    public class RoomImageUpdateDTO:IDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
    }
}