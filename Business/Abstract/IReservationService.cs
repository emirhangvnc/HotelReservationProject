using Business.Abstract.Base;
using Entities.Concrete;
using Entities.DTOs.Concrete.ReservationDTO;

namespace Business.Abstract
{
    public interface IReservationService : IBaseService<Reservation,
        ReservationAddDTO, ReservationDeleteDTO, ReservationUpdateDTO>
    {
    }
}