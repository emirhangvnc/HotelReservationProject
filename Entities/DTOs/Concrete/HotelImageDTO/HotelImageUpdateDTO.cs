using Core.Entities;

namespace Entities.DTOs.Concrete.HotelImageDTO
{
    public class HotelImageUpdateDTO:IDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
    }
}