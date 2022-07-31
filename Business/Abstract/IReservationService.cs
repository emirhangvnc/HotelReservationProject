using Business.Abstract.Base;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Concrete.ReservationDTO;

namespace Business.Abstract
{
    public interface IReservationService : IBaseService<Reservation,
        ReservationAddDTO, ReservationDeleteDTO, ReservationUpdateDTO>
    {
        IDataResult<List<Reservation>> GetReservationByUserId(int id);
        IDataResult<List<Reservation>> GetActiveReservationByUserId(int id);
    }
}