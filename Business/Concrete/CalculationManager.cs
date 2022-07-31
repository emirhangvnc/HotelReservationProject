using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CalculationManager : ICalculationService
    {
        IRoomService _roomService;
        IMapper _mapper;

        public CalculationManager(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public IDataResult<Reservation> ReservationCalculation(Reservation reservation)
        {
            var result = _roomService.GetById(reservation.RoomId);
            var weekendDay = Convert.ToInt16(WeekendCalculation(reservation.Checkin, reservation.Checkout));
            var totalDays = (reservation.Checkout - reservation.Checkin).Days;

            if (result == null)
                return new ErrorDataResult<Reservation>(result.Message);

            if (reservation.UserNumber == result.Data.StandartBad)
            {
                var increase = Convert.ToDecimal(PricePercentageCalculation(result.Data.Price, 30));
                reservation.Total = ((totalDays - weekendDay) * result.Data.Price) + (weekendDay*(result.Data.Price + increase));
            }
            else if (reservation.UserNumber == result.Data.StandartBad - 1)
            {
                var sale = Convert.ToDecimal(PricePercentageCalculation(result.Data.Price,30));
                reservation.Total = (totalDays - weekendDay) * (result.Data.Price - sale) + (weekendDay * (result.Data.Price + sale));
            }
            else if (reservation.UserNumber == result.Data.StandartBad + 1)
            {
                var increase = Convert.ToDecimal(PricePercentageCalculation(result.Data.Price, 20));
                reservation.Total = (totalDays - weekendDay) * (result.Data.Price + increase) + (weekendDay * (result.Data.Price + increase));
            }
            else
                return new ErrorDataResult<Reservation>("Hesaplamada Bir Sorun Oluştu");

            return new SuccessDataResult<Reservation>(reservation);
        }
        public IResult PricePercentageCalculation(decimal price,int oran)
        {
            var percentage = (price * oran) / 100;
            return new SuccessResult(percentage.ToString());
        }

        public IResult WeekendCalculation(DateTime chIn, DateTime chOf)
        {
            if (chIn > chOf)
                return new ErrorResult("Geçersiz Zaman Aralığı");

            var totalDays = (chOf - chIn).TotalDays;
            double weekendDays =
            (totalDays * 5 -
            (chIn.DayOfWeek - chOf.DayOfWeek) * 2) / 7;

            if (chOf.DayOfWeek == DayOfWeek.Saturday) weekendDays--;
            if (chIn.DayOfWeek == DayOfWeek.Sunday) weekendDays--;
            return new SuccessResult($"{totalDays - weekendDays}");
        }
    }
}