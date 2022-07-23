using Core.Entities;
using Entities.Concrete.Base;

namespace Entities.Concrete.Image
{
    public class HotelImage : IBaseDate<DateTime>, IBaseImage, IEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public byte[] ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}