using Business.Abstract;
using Entities.DTOs.Concrete.RoomImageDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImagesController : ControllerBase
    {
        IRoomImageService _roomImageService;

        public RoomImagesController(IRoomImageService roomImageService)
        {
            _roomImageService = roomImageService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _roomImageService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByRoomImageId(int roomImageId)
        {
            var result = _roomImageService.GetById(roomImageId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file,RoomImageAddDTO roomImageAddDTO)
        {
            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            var result = _roomImageService.Add(file, roomImageAddDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete([FromForm(Name = ("Image"))] IFormFile formFile, RoomImageDeleteDTO roomImageDeleteDTO)
        {
            var result = _roomImageService.Delete(formFile, roomImageDeleteDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile formFile, RoomImageUpdateDTO roomImageUpdateDTP)
        {
            var result = _roomImageService.Update(formFile, roomImageUpdateDTP);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}