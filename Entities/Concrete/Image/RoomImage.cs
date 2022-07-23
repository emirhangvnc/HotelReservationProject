using Core.Entities;
using Entities.Concrete.Base;

namespace Entities.Concrete.Image
{
    public class RoomImage : IBaseDate<DateTime>, IBaseImage, IEntity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public byte[] ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}