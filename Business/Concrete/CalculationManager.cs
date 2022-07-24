using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Concrete.ReservationDTO;

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
            var dateTime = reservation.Checkout - reservation.Checkin;
            var result = _roomService.GetById(reservation.RoomId);

            if (result == null)
                return new ErrorDataResult<Reservation>(result.Message);

            if (reservation.UserNumber == result.Data.StandartBad)
            {
                reservation.Total= dateTime.Days * result.Data.Price;
            }
            else if (reservation.UserNumber==result.Data.StandartBad-1)
            {
                var sale = (result.Data.Price * 30) / 100;
                reservation.Total = dateTime.Days * (result.Data.Price-sale);
            }
            else if (reservation.UserNumber == result.Data.StandartBad + 1)
            {
                var increase = (result.Data.Price * 20) / 100;
                reservation.Total = dateTime.Days * (result.Data.Price + increase);
            }
            else
                return new ErrorDataResult<Reservation>("Hesaplamada Bir Sorun Oluştu");

            return new SuccessDataResult<Reservation>(reservation);
        }

        private IResult WeekendCalculation(DateTime ChIn, DateTime ChOf)
        {
            //Yapılacak
            return new ErrorResult();
        }
    }
}