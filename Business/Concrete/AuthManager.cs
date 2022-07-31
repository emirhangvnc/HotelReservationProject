using Business.Abstract;
using Business.ValidationRules.FluentValidation.AuthValidator;
using Business.ValidationRules.FluentValidation.UserValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.DTOs.Concrete.AuthDTO;
using Entities.DTOs.Concrete.UserDTO;
using Shared.Entities.Concrete;
using Shared.Utilities.Security.Hashing;
using Shared.Utilities.Security.JWT;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        [ValidationAspect(typeof(UserForLoginDTOValidator))]
        public IDataResult<User> Login(UserForLoginDTO userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
                return new ErrorDataResult<User>("Kullanici Bulunamadi");

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
                return new ErrorDataResult<User>("Şifre Hatalı");

            return new SuccessDataResult<User>(userToCheck.Data, "Giriş Başarılı");
        }
        [ValidationAspect(typeof(UserForRegisterDTOValidator))]
        public IDataResult<User> Register(UserForRegisterDTO userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new UserAddDTO
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>();
        }

        public IResult UserExists(string email)
        {
            IResult result = BusinessRules.Run(CheckIfUserExist(email));
            if (result != null)
                return new ErrorResult();
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        private IResult CheckIfUserExist(string email)
        {
            var result = _userService.GetByMail(email).Data;
            if (result != null)
                return new ErrorResult();
            return new SuccessResult();
        }
    }
}