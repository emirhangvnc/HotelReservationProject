using Core.Entities;

namespace Entities.Concrete.Info
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public IList<City> Cities { get; set; }
    }
}