using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation.ReservationValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete.ReservationDTO;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;
        private readonly ICalculationService _calculationService;
        private readonly IMapper _mapper;

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
        public IDataResult<List<Reservation>> GetReservationByUserId(int id)
        {
            var result = _reservationDal.GetAll(r => r.UserId == id);
            if (result == null)
                return new ErrorDataResult<List<Reservation>>("Bu Kullanıcının Bir Rezervasyonu Bulunmamaktadır");
            return new SuccessDataResult<List<Reservation>>(result, "Kullanıcının Rezervasyonları Listelendi");
        }
        public IDataResult<List<Reservation>> GetActiveReservationByUserId(int id)
        {
            var result = _reservationDal.GetAll(r => r.UserId == id&&r.Checkout>DateTime.Now);
            if (result == null)
                return new ErrorDataResult<List<Reservation>>("Bu Kullanıcının Aktif Rezervasyonu Bulunmamaktadır");
            return new SuccessDataResult<List<Reservation>>(result, "Kullanıcının Aktif Rezervasyonları Listelendi");
        }
        [ValidationAspect(typeof(ReservationAddDTOValidator))]
        public IResult Add(ReservationAddDTO addedDto)
        {
            var reservation = _mapper.Map<Reservation>(addedDto);
            var newReservation = _calculationService.ReservationCalculation(reservation);
            _reservationDal.Add(newReservation.Data);
            return new SuccessResult("Rezervasyon Eklendi");
        }
        [ValidationAspect(typeof(ReservationDeleteDTOValidator))]
        public IResult Delete(ReservationDeleteDTO deletedDto)
        {
            var result = _reservationDal.Get(r => r.Id == deletedDto.Id);
            if (result == null)
                return new ErrorResult("Rezervasyon Bulunamadı");

            _reservationDal.Delete(result);
            return new SuccessResult("Rezervasyon Silindi");
        }
        [ValidationAspect(typeof(ReservationUpdateDTOValidator))]
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