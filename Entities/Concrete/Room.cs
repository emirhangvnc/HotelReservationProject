using Core.Entities;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class Room: IBaseDate<DateTime>, IEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StandartBad { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}