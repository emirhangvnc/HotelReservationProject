using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Concrete.ReservationDTO;

namespace Business.Abstract
{
    public interface ICalculationService
    {
        IDataResult<Reservation> ReservationCalculation(Reservation reservation);
    }
}