using Business.Abstract.Base;
using Entities.Concrete.Info;
using Entities.DTOs.Concrete.CountryDTO;

namespace Business.Abstract
{
    public interface ICountryService : IBaseService<Country,
        CountryAddDTO, CountryDeleteDTO, CountryUpdateDTO>
    {
    }
}