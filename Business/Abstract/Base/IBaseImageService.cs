using Core.Entities;

namespace Business.Abstract.Base
{
    public interface IBaseImageService<TEntity, TAddImageDTO, TDeleteImageDTO, TUpdateImageDTO> :
        IGetService<TEntity>, IAddImageDtoService<TAddImageDTO>, IDeleteImageDtoService<TDeleteImageDTO>, IUpdateImageDtoService<TUpdateImageDTO>
        where TEntity : IEntity, new()
        where TAddImageDTO : IDto, new()
        where TDeleteImageDTO : IDto, new()
        where TUpdateImageDTO : IDto, new()
    {
    }
}