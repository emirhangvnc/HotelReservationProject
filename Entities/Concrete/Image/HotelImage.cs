using Core.Entities;
using Entities.Concrete.Base;

namespace Entities.Concrete.Image
{
    public class HotelImage : IBaseDate<DateTime>, IEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}