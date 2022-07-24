using Core.Entities;

namespace Entities.DTOs.Concrete.RoomDTO
{
    public class RoomAddDTO:IDto
    {
        public int HotelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StandartBad { get; set; }
    }
}