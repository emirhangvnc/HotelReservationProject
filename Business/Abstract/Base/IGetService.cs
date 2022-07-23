using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract.Base
{
    public interface IGetService<T> where T : IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
    }
}