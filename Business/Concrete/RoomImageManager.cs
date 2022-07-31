using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.RoomImageValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Image;
using Entities.DTOs.Concrete.RoomImageDTO;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class RoomImageManager : IRoomImageService
    {
        IRoomImageDal _roomImageDal;
        readonly IMapper _mapper;

        public RoomImageManager(IRoomImageDal roomImageDal, IMapper mapper)
        {
            _roomImageDal = roomImageDal;
            _mapper = mapper;
        }
        public IDataResult<List<RoomImage>> GetAll()
        {
            return new SuccessDataResult<List<RoomImage>>(_roomImageDal.GetAll(), "Oda Resimleri Listelendi");
        }

        public IDataResult<RoomImage> GetById(int id)
        {
            return new SuccessDataResult<RoomImage>(_roomImageDal.Get(h => h.Id == id), "Oda Resimi Listelendi");
        }
        [ValidationAspect(typeof(RoomImageAddDTOValidator))]
        public IResult Add(IFormFile file, RoomImageAddDTO addedDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExtensionValid(file),
                CheckIfImageLimitExpired(addedDto.RoomId)
                );

            if (result != null)
                return result;

            var image = _mapper.Map<RoomImage>(addedDto);
            image.ImagePath = FileHelper.Add(file);
            image.CreatedDate = DateTime.Now;
            image.UpdatedDate = DateTime.Now;
            _roomImageDal.Add(image);
            return new SuccessResult("Oda Eklendi");
        }
        [ValidationAspect(typeof(RoomImageDeleteDTOValidator))]
        public IResult Delete(IFormFile file, RoomImageDeleteDTO deletedDto)
        {
            IResult result = BusinessRules.Run(
               CheckIfImageExists(deletedDto.Id)
               );
            if (result != null)
                return result;

            var roomImage = _mapper.Map<RoomImage>(deletedDto);
            var path = GetById(deletedDto.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _roomImageDal.Delete(roomImage);
            return new SuccessResult("Oda Resmi Silindi");
        }
        [ValidationAspect(typeof(RoomImageUpdateDTOValidator))]
        public IResult Update(IFormFile file, RoomImageUpdateDTO updatedDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExtensionValid(file),
                CheckIfImageExists(updatedDto.Id)
                );

            if (result != null)
                return result;

            var roomImage = _mapper.Map<RoomImage>(updatedDto);
            var oldRoomImage = GetById(roomImage.Id).Data;
            roomImage.ImagePath = FileHelper.Update(file, oldRoomImage.ImagePath);
            roomImage.UpdatedDate = DateTime.Now;
            _roomImageDal.Update(roomImage);
            return new SuccessResult("Oda Resmi Güncellendi");
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
            if (_roomImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.HotelImageMustBeExists);
        }

        private IResult CheckIfImageLimitExpired(int id)
        {
            int result = _roomImageDal.GetAll(r => r.RoomId == id).Count;
            if (result >= 5)
                return new ErrorResult("En Fazla 5 Oda Resmi Eklenebilir");
            return new SuccessResult();
        }
    }
}