using Core.Entities;
using Entities.DTOs.Base;

namespace Entities.DTOs.Concrete.CityDTO
{
    public class CityUpdateDTO : BaseIdDTO, IDto
    {
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
    }
}