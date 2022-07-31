using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation.RoomValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete.RoomDTO;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;
        readonly IMapper _mapper;

        public RoomManager(IRoomDal roomDal, IMapper mapper)
        {
            _roomDal = roomDal;
            _mapper = mapper;
        }
        public IDataResult<List<Room>> GetAll()
        {
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll());
        }

        public IDataResult<Room> GetById(int id)
        {
            var result = _roomDal.Get(h => h.Id == id);
            if (result == null)
                return new ErrorDataResult<Room>("Böyle Bir Oda Bulunmamaktadır");
            return new SuccessDataResult<Room>(result, "Oda Listelendi");
        }

        public IDataResult<List<RoomDetailDTO>> GetRoomDetails()
        {
            return new SuccessDataResult<List<RoomDetailDTO>>(_roomDal.GetRoomDetails());
        }
        [ValidationAspect(typeof(RoomAddDTOValidator))]
        public IResult Add(RoomAddDTO addedDto)
        {
            var room = _mapper.Map<Room>(addedDto);
            room.CreatedDate = DateTime.Now;
            room.UpdatedDate = DateTime.Now;
            _roomDal.Add(room);
            return new SuccessResult("Oda Eklendi");
        }
        [ValidationAspect(typeof(RoomDeleteDTOValidator))]
        public IResult Delete(RoomDeleteDTO deletedDto)
        {
            var result = _roomDal.Get(u => u.Id == deletedDto.Id);
            if (result == null)
                return new ErrorResult("Oda Bulunamadı");

            _roomDal.Delete(result);
            return new SuccessResult("Oda Silindi");
        }
        [ValidationAspect(typeof(RoomUpdateDTOValidator))]
        public IResult Update(RoomUpdateDTO updatedDto)
        {
            var result = _roomDal.Get(u => u.Id == updatedDto.Id);
            if (result == null)
                return new ErrorResult("Oda Bulunamadı");

            var room = _mapper.Map(updatedDto, result);
            room.UpdatedDate = DateTime.Now;
            _roomDal.Update(room);
            return new SuccessResult("Oda Güncellendi");
        }
    }
}