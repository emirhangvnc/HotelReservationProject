using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete.HotelDTO;

namespace Business.Concrete
{
    public class HotelManager : IHotelService
    {
        IHotelDal _hotelDal;
        readonly IMapper _mapper;

        public HotelManager(IHotelDal hotelDal,IMapper mapper)
        {
            _hotelDal = hotelDal;
            _mapper = mapper;
        }
        public IDataResult<List<Hotel>> GetAll()
        {
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetAll());
        }

        public IDataResult<Hotel> GetById(int id)
        {
            var result = _hotelDal.Get(h => h.Id == id);
            if (result == null)
                return new ErrorDataResult<Hotel>("Böyle Bir Hotel Bulunmamaktadır");
            return new SuccessDataResult<Hotel>(result,"Otel Listelendi");
        }

        public IResult Add(HotelAddDTO addedDto)
        {
            var hotel = _mapper.Map<Hotel>(addedDto);
            hotel.CreatedDate = DateTime.Now;
            hotel.UpdatedDate = DateTime.Now;
            _hotelDal.Add(hotel);
            return new SuccessResult("Otel Eklendi");
        }

        public IResult Delete(HotelDeleteDTO deletedDto)
        {
            var result = _hotelDal.Get(u => u.Id == deletedDto.Id);
            if (result == null)
                return new ErrorResult("Otel Bulunamadı");

            _hotelDal.Delete(result);
            return new SuccessResult("Otel Silindi");
        }

        public IResult Update(HotelUpdateDTO updatedDto)
        {
            var result = _hotelDal.Get(u => u.Id == updatedDto.Id);
            if (result == null)
                return new ErrorResult("Otel Bulunamadı");

            var hotel = _mapper.Map(updatedDto, result);
            hotel.UpdatedDate = DateTime.Now;
            _hotelDal.Update(hotel);
            return new SuccessResult("Otel Güncellendi");
        }
    }
}