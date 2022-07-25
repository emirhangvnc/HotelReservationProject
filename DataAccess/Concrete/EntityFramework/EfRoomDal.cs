using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs.Concrete.RoomDTO;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoomDal:EfEntityRepositoryBase<Room,HotelReservationContext>,IRoomDal
    {
        public List<RoomDetailDTO> GetRoomDetails(Expression<Func<RoomDetailDTO, bool>> filter = null)
        {
            using (HotelReservationContext context = new HotelReservationContext())
            {
                var result = from r in context.rooms
                             join h in context.hotels
                             on r.HotelId equals h.Id
                             join ri in context.roomImages
                             on r.Id equals ri.RoomId

                             select new RoomDetailDTO
                             {
                                 Title=r.Title,
                                 Description=r.Description,
                                 HotelName=h.HotelName,
                                 Price=r.Price,
                                 StandartBad=r.StandartBad,
                                 RoomImage=ri.ImagePath
                             };
                return filter == null ?
                    result.ToList() :
                    result.Where(filter).ToList();
            }
        }
    }
}