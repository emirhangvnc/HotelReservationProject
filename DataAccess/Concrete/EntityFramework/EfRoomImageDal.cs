using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete.Image;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoomImageDal : EfEntityRepositoryBase<RoomImage, HotelReservationContext>, IRoomImageDal
    {
        public bool IsExist(int id)
        {
            using (HotelReservationContext context = new HotelReservationContext())
            {
                return context.RoomImages.Any(r => r.Id == id);
            }
        }
    }
}