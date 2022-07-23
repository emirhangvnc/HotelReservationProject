using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract.Base
{
    public interface IDeleteDtoService<T> where T : IDto, new()
    {
        IResult Delete(T deletedDto);
    }
}