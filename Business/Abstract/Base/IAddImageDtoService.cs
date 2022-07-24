using Core.Entities;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract.Base
{
    public interface IAddImageDtoService<T> where T : IDto, new()
    {
        IResult Add(IFormFile file, T addedDto);
    }
}