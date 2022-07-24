using Core.Entities;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract.Base
{
    public interface IDeleteImageDtoService<T> where T : IDto, new()
    {
        IResult Delete(IFormFile file, T deletedDto);
    }
}