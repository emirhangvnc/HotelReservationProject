using Core.Entities;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class Hotel: IBaseDate<DateTime>, IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int SocialMediaId { get; set; }
        public string HotelName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}