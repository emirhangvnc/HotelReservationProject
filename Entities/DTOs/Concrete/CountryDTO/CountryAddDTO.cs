using Core.Entities;

namespace Entities.DTOs.Concrete.CountryDTO
{
    public class CountryAddDTO : IDto
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}