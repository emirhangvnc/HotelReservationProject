using Business.Abstract;
using Entities.DTOs.Concrete.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(UserDeleteDTO userDeleteDto)
        {
            var result = _userService.Delete(userDeleteDto);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(UserUpdateDTO userUpdateDto)
        {
            var result = _userService.Update(userUpdateDto);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}