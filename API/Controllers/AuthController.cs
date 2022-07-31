using Business.Abstract;
using Entities.DTOs.Concrete.AuthDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("[action]")]
        public ActionResult Login(UserForLoginDTO userForLoginDTO)
        {
            var userToLogin = _authService.Login(userForLoginDTO);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpPost]
        [Route("[action]")]
        public ActionResult Register(UserForRegisterDTO userForRegisterDTO)
        {
            var userExists = _authService.UserExists(userForRegisterDTO.Email);
            if (!userExists.Success)
                return BadRequest(userExists.Message);

            var registerResult = _authService.Register(userForRegisterDTO);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }
    }
}