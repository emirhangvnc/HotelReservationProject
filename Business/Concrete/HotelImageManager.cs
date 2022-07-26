using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Image;
using Entities.DTOs.Concrete.HotelImageDTO;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    public class HotelImageManager:IHotelImageService
    {
        IHotelImageDal _hotelImageDal;
        readonly IMapper _mapper;

        public HotelImageManager(IHotelImageDal hotelImageDal, IMapper mapper)
        {
            _hotelImageDal = hotelImageDal;
            _mapper = mapper;
        }
        public IDataResult<List<HotelImage>> GetAll()
        {
            return new SuccessDataResult<List<HotelImage>>(_hotelImageDal.GetAll(), "Oteller Listelendi");
        }

        public IDataResult<HotelImage> GetById(int id)
        {
            return new SuccessDataResult<HotelImage>(_hotelImageDal.Get(h => h.Id == id), "Otel Listelendi");
        }
        public IResult Add(IFormFile file, HotelImageAddDTO addedDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExtensionValid(file)
                );

            if (result != null)
                return result;

            var image = _mapper.Map<HotelImage>(addedDto);
            image.ImagePath = FileHelper.Add(file);
            image.CreatedDate = DateTime.Now;
            image.UpdatedDate = DateTime.Now;
            _hotelImageDal.Add(image);
            return new SuccessResult("Otel Eklendi");
        }
        public IResult Delete(IFormFile file, HotelImageDeleteDTO deletedDto)
        {
            IResult result = BusinessRules.Run(
               CheckIfImageExists(deletedDto.Id)
               );
            if (result != null)
                return result;

            var hotelImage = _mapper.Map<HotelImage>(deletedDto);
            var path = GetById(deletedDto.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _hotelImageDal.Delete(hotelImage);
            return new SuccessResult("Otel Resmi Silindi");
        }
        public IResult Update(IFormFile file, HotelImageUpdateDTO updatedDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExtensionValid(file),
                CheckIfImageExists(updatedDto.Id)
                );

            if (result != null)
                return result;

            var hotelImage = _mapper.Map<HotelImage>(updatedDto);
            var oldHotelImage = GetById(hotelImage.Id).Data;
            hotelImage.ImagePath = FileHelper.Update(file, oldHotelImage.ImagePath);
            hotelImage.UpdatedDate = DateTime.Now;
            _hotelImageDal.Update(hotelImage);
            return new SuccessResult("Otel Resmi Güncellendi");
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.InvalidImageExtension);
            return new SuccessResult();
        }
        private IResult CheckIfImageExists(int id)
        {
            if (_hotelImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.HotelImageMustBeExists);
        }
    }
}