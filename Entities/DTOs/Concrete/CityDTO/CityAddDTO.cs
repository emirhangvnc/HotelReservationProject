using Core.Entities;

namespace Entities.DTOs.Concrete.CityDTO
{
    public class CityAddDTO : IDto
    {
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
    }
}