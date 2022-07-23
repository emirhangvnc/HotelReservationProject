using Core.Entities;

namespace Entities.Concrete.Base
{
    public interface IBaseDate<T>
    {
        public T CreatedDate { get; set; }
        public T UpdatedDate { get; set; }
    }
}