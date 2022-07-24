using Core.Entities;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract.Base
{
    public interface IUpdateImageDtoService<T> where T : IDto, new()
    {
        IResult Update(IFormFile file, T updatedDto);
    }
}