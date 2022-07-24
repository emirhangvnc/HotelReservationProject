using Core.Entities;
using Entities.Concrete.Info;

namespace DataAccess.Abstract
{
    public interface ICountryDal : IEntityRepository<Country>
    {
    }
}