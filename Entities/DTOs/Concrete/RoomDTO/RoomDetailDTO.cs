using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs.Concrete.RoomDTO
{
    public class RoomDetailDTO : IDto
    {
        public string Title { get; set; }
        public string RoomImage { get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StandartBad { get; set; }
    }
}