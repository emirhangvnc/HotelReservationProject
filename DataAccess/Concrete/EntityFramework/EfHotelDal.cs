using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs.Concrete.HotelDTO;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHotelDal:EfEntityRepositoryBase<Hotel,HotelReservationContext>,IHotelDal
    {
        public List<HotelDetailDTO> GetHotelDetails(Expression<Func<HotelDetailDTO, bool>> filter = null)
        {
            using (HotelReservationContext context = new HotelReservationContext())
            {
                var result = from h in context.hotels
                             join r in context.rooms
                             on h.Id equals r.HotelId
                             join hi in context.hotelImages
                             on h.Id equals hi.HotelId
                             join c in context.cities
                             on h.CityId equals c.Id
                             join co in context.countries
                             on c.CountryId equals co.Id

                             select new HotelDetailDTO
                             {
                                 HotelImage = hi.ImagePath,
                                 Address=h.Address,
                                 HotelName=h.HotelName,
                                 PhoneNumber=h.PhoneNumber,
                                 CountryName=co.CountryName,
                                 CityName=c.CityName,
                                 Rooms= (from i in context.rooms where i.HotelId == h.Id select i).ToList()
                             };
                return filter == null ?
                    result.ToList() :
                    result.Where(filter).ToList();
            }
        }
    }
}