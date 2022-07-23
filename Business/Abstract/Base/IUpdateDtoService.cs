using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract.Base
{
    public interface IUpdateDtoService<T> where T : IDto, new()
    {
        IResult Update(T updatedDto);
    }
}