using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Info;
using Entities.DTOs.Concrete.CountryDTO;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;
        IMapper _mapper;

        public CountryManager(ICountryDal countryDal, IMapper mapper)
        {
            _countryDal = countryDal;
            _mapper = mapper;
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll());
        }

        public IDataResult<Country> GetById(int id)
        {
            var result = _countryDal.Get(c => c.Id == id);
            if (result == null)
                return new ErrorDataResult<Country>("Ülke Bulunamadı");
            return new SuccessDataResult<Country>(result);
        }

        public IResult Add(CountryAddDTO addedDto)
        {
            var result = _countryDal.Get(c => c.CountryCode == addedDto.CountryCode);
            if (result == null)
                return new ErrorResult($"Böyle Bir Ülke Zaten Mevcut");

            var country = _mapper.Map<Country>(addedDto);
            _countryDal.Add(country);
            return new SuccessResult("Ülke Eklendi");
        }

        public IResult Delete(CountryDeleteDTO deletedDto)
        {
            var result = _countryDal.Get(u => u.Id == deletedDto.Id);
            if (result == null)
                return new ErrorResult("Ülke Bulunamadı");

            _countryDal.Delete(result);
            return new SuccessResult("Ülke Silindi");
        }

        public IResult Update(CountryUpdateDTO updatedDto)
        {
            var result = _countryDal.Get(u => u.Id == updatedDto.Id);
            if (result == null)
                return new ErrorResult("Ülke Bulunamadı");

            var country = _mapper.Map(updatedDto, result);
            _countryDal.Update(country);
            return new SuccessResult("Ülke Güncellendi");
        }
    }
}