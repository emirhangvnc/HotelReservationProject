using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete.Image;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHotelImageDal : EfEntityRepositoryBase<HotelImage, HotelReservationContext>, IHotelImageDal
    {
        public bool IsExist(int id)
        {
            using (HotelReservationContext context = new HotelReservationContext())
            {
                return context.hotelImages.Any(h => h.Id == id);
            }
        }
    }
}