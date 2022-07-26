using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation.CityValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Info;
using Entities.DTOs.Concrete.CityDTO;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        IMapper _mapper;

        public CityManager(ICityDal cityDal, IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll());
        }

        public IDataResult<City> GetById(int id)
        {
            var result = _cityDal.Get(c => c.Id == id);
            if(result==null)
                return new ErrorDataResult<City>("Şehir Bulunamadı");
            return new SuccessDataResult<City>(result);
        }
        [ValidationAspect(typeof(CityAddDTOValidator))]
        public IResult Add(CityAddDTO addedDto)
        {
            var result = _cityDal.Get(c => c.CityCode == addedDto.CityCode);
            if (result == null)
                return new ErrorResult($"Böyle Bir Şehir Zaten Mevcut");

            var city = _mapper.Map<City>(addedDto);
            _cityDal.Add(city);
            return new SuccessResult("Şehir Eklendi");
        }
        [ValidationAspect(typeof(CityDeleteDTOValidator))]
        public IResult Delete(CityDeleteDTO deletedDto)
        {
            var result = _cityDal.Get(u => u.Id == deletedDto.Id);
            if (result == null)
                return new ErrorResult("Şehir Bulunamadı");

            _cityDal.Delete(result);
            return new SuccessResult("Şehir Silindi");
        }
        [ValidationAspect(typeof(CityUpdateDTOValidator))]
        public IResult Update(CityUpdateDTO updatedDto)
        {
            var result = _cityDal.Get(u => u.Id == updatedDto.Id);
            if (result == null)
                return new ErrorResult("Şehir Bulunamadı");

            var city = _mapper.Map(updatedDto, result);
            _cityDal.Update(city);
            return new SuccessResult("Şehir Güncellendi");
        }
    }
}