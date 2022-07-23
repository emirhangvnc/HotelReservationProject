using Core.Entities;
using Entities.DTOs.Base;

namespace Entities.DTOs.Concrete.HotelDTO
{
    public class HotelDeleteDTO : IBaseId<int>, IDto
    {
        public int Id { get; set; }
    }
}