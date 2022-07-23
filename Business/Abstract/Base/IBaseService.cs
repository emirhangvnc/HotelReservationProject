using Core.Entities;

namespace Business.Abstract.Base
{
    public interface IBaseService<TEntity,TAddDTO,TDeleteDTO, TUpdateDTO> :
        IGetService<TEntity>,IAddDtoService<TAddDTO>, IDeleteDtoService<TDeleteDTO>, IUpdateDtoService<TUpdateDTO> 
        where TEntity : IEntity, new()
        where TAddDTO : IDto, new()
        where TDeleteDTO : IDto, new()
        where TUpdateDTO : IDto, new()
    {
    }
}