using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation.UserValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Concrete.UserDTO;
using Shared.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper, IReservationService reservationService)
        {
            _userDal = userDal;
            _mapper = mapper;
            _reservationService = reservationService;
        }

        public IDataResult<List<OperationClaim>> GetClaims(int id)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
                return new ErrorDataResult<User>($"Böyle Bir Kullanıcı Yok");
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result==null)
                return new ErrorDataResult<User>("Kullanıcı Bulunamadı");
            return new SuccessDataResult<User>(result);
        }
        [ValidationAspect(typeof(UserAddDTOValidator))]
        public IResult Add(UserAddDTO addedDto)
        {
            var result = _userDal.Get(c => c.Email == addedDto.Email);
            if (result == null)
                return new ErrorResult($"Böyle Bir E-Mail Zaten Mevcut");

            var user = _mapper.Map<User>(addedDto);
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı Eklendi");
        }
        [ValidationAspect(typeof(UserDeleteDTOValidator))]
        public IResult Delete(UserDeleteDTO deletedDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserReservation(deletedDto.Id)
                );
            if (result != null)
                return result;

            var user = _userDal.Get(u=>u.Id==deletedDto.Id);
            if (user == null)
                return new ErrorResult("Kullanıcı Bulunamadı");

            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı Silindi");
        }
        [ValidationAspect(typeof(UserUpdateDTOValidator))]
        public IResult Update(UserUpdateDTO updatedDto)
        {
            var result = _userDal.Get(u => u.Id == updatedDto.Id);
            if (result == null)
                return new ErrorResult("Kullanıcı Bulunamadı");

            var user = _mapper.Map(updatedDto, result);
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı Güncellendi");
        }

        private IResult CheckIfUserReservation(int id)
        {
            var result = _reservationService.GetActiveReservationByUserId(id);
            if (result.Data!=null)
                return new ErrorResult("Kullanıcının Aktif Reservasyonları Mevcut, Bu Kullanıcı Silinemez");
            return new SuccessResult("Üye Silinebilir");
        }
    }
}