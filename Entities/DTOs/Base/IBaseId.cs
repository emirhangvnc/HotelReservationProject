
namespace Entities.DTOs.Base
{
    public interface IBaseId<T> 
        where T : new()
    {
        public T Id { get; set; }
    }
}