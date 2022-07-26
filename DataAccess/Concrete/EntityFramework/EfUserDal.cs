using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Shared.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HotelReservationContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(int id)
        {
            using (var context=new HotelReservationContext())
            {
                var result = from operationClaim in context.operationClaims
                             join userOperationClaim in context.userOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}