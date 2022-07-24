using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.Concrete.UserDTO;
using Shared.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        readonly IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
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

        public IResult Add(UserAddDTO addedDto)
        {
            var result = _userDal.Get(c => c.Email == addedDto.Email);
            if (result == null)
                return new ErrorResult($"Böyle Bir E-Mail Zaten Mevcut");

            var user = _mapper.Map<User>(addedDto);
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı Eklendi");
        }

        public IResult Delete(UserDeleteDTO deletedDto)
        {
            var result = _userDal.Get(u=>u.Id==deletedDto.Id);
            if (result == null)
                return new ErrorResult("Kullanıcı Bulunamadı");

            _userDal.Delete(result);
            return new SuccessResult("Kullanıcı Silindi");
        }

        public IResult Update(UserUpdateDTO updatedDto)
        {
            var result = _userDal.Get(u => u.Id == updatedDto.Id);
            if (result == null)
                return new ErrorResult("Kullanıcı Bulunamadı");

            var user = _mapper.Map(updatedDto, result);
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı Güncellendi");
        }
    }
}