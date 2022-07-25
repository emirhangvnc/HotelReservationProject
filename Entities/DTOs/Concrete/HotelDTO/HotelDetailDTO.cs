using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs.Concrete.HotelDTO
{
    public class HotelDetailDTO : IDto
    {
        public string HotelName { get; set; }
        public string HotelImage { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public List<Room> Rooms { get; set; }
    }
}