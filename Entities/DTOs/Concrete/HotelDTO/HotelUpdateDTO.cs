using Core.Entities;
using Entities.DTOs.Base;

namespace Entities.DTOs.Concrete.HotelDTO
{
    public class HotelUpdateDTO :IBaseId<int>, IDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string HotelName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}