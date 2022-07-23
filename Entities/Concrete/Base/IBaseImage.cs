
namespace Entities.Concrete.Base
{
    public interface IBaseImage
    {
        public int Id { get; set; }
        public byte[] ImagePath { get; set; }
    }
}