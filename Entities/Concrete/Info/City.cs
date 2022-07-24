using Core.Entities;

namespace Entities.Concrete.Info
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
    }
}