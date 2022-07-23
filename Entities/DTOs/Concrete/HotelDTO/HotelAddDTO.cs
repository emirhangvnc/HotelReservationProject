using Core.Entities;

namespace Entities.DTOs.Concrete.HotelDTO
{
    public class HotelAddDTO:IDto
    {
        public int CityId { get; set; }
        public string HotelName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}