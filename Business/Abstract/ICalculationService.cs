using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Concrete.ReservationDTO;

namespace Business.Abstract
{
    public interface ICalculationService
    {
        IDataResult<Reservation> ReservationCalculation(Reservation reservation);
        IResult WeekendCalculation(DateTime startDate,DateTime endDate);
        IResult PricePercentageCalculation(decimal price, int ratio);
    }
}