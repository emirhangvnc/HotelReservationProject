using Core.Entities;

namespace Entities.Concrete
{
    public class SocialMedia:IEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? YoutubeUrl { get; set; }
    }
}