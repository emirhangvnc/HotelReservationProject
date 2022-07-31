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
                var result = from h in context.Hotels
                             join r in context.Rooms
                             on h.Id equals r.HotelId
                             join hi in context.HotelImages
                             on h.Id equals hi.HotelId
                             join c in context.Cities
                             on h.CityId equals c.Id
                             join co in context.Countries
                             on c.CountryId equals co.Id

                             select new HotelDetailDTO
                             {
                                 HotelImage = hi.ImagePath,
                                 Address=h.Address,
                                 HotelName=h.HotelName,
                                 PhoneNumber=h.PhoneNumber,
                                 CountryName=co.CountryName,
                                 CityName=c.CityName,
                                 Rooms= (from i in context.Rooms where i.HotelId == h.Id select i).ToList()
                             };
                return filter == null ?
                    result.ToList() :
                    result.Where(filter).ToList();
            }
        }
    }
}