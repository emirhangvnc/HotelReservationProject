using Business.Abstract.Base;
using Core.Utilities.Results;
using Entities.DTOs.Concrete.UserDTO;
using Shared.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IBaseService<User,
        UserAddDTO, UserDeleteDTO, UserUpdateDTO>
    {
        IDataResult<List<OperationClaim>> GetClaims(int id);
        IDataResult<User> GetByMail(string email);
    }
}