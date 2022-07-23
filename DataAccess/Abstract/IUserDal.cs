using Entities.Concrete;
using Core.Entities;
using Shared.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(int id);
    }
}