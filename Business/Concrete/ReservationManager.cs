using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete.ReservationDTO;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;
        ICalculationService _calculationService;
        readonly IMapper _mapper;

        public ReservationManager(IReservationDal reservationDal, IMapper mapper, ICalculationService calculationService)
        {
            _reservationDal = reservationDal;
            _calculationService = calculationService;
            _mapper = mapper;
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll());
        }

        public IDataResult<Reservation> GetById(int id)
        {
            var result = _reservationDal.Get(r => r.Id == id);
            if (result == null)
                return new ErrorDataResult<Reservation>("Böyle Bir Rezervasyon Bulunmamaktadır");
            return new SuccessDataResult<Reservation>(result, "Rezervasyon Listelendi");
        }

        public IResult Add(ReservationAddDTO addedDto)
        {
            var reservation = _mapper.Map<Reservation>(addedDto);
            var newReservation = _calculationService.ReservationCalculation(reservation);
            _reservationDal.Add(newReservation.Data);
            return new SuccessResult("Rezervasyon Eklendi");
        }

        public IResult Delete(ReservationDeleteDTO deletedDto)
        {
            var result = _reservationDal.Get(r => r.Id == deletedDto.Id);
            if (result == null)
                return new ErrorResult("Rezervasyon Bulunamadı");

            _reservationDal.Delete(result);
            return new SuccessResult("Rezervasyon Silindi");
        }

        public IResult Update(ReservationUpdateDTO updatedDto)
        {
            var result = _reservationDal.Get(r => r.Id == updatedDto.Id);
            if (result == null)
                return new ErrorResult("Rezervasyon Bulunamadı");

            var reservation = _mapper.Map(updatedDto, result);
            var newReservation = _calculationService.ReservationCalculation(reservation);
            _reservationDal.Update(newReservation.Data);
            return new SuccessResult("Rezervasyon Güncellendi");
        }
    }
}