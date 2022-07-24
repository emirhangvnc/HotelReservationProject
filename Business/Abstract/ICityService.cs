using Business.Abstract.Base;
using Entities.Concrete.Info;
using Entities.DTOs.Concrete.CityDTO;

namespace Business.Abstract
{
    public interface ICityService : IBaseService<City,
        CityAddDTO, CityDeleteDTO, CityUpdateDTO>
    {
    }
}