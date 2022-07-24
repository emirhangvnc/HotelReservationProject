using Core.Entities;
using Entities.DTOs.Base;

namespace Entities.DTOs.Concrete.CountryDTO
{
    public class CountryUpdateDTO : BaseIdDTO, IDto
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}