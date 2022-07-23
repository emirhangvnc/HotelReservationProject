using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract.Base
{
    public interface IAddDtoService<T> where T : IDto, new()
    {
        IResult Add(T addedDto);
    }
}