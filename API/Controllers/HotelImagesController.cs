using Business.Abstract;
using Entities.DTOs.Concrete.HotelImageDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelImagesController : ControllerBase
    {
        IHotelImageService _hotelImageService;

        public HotelImagesController(IHotelImageService hotelImageService)
        {
            _hotelImageService = hotelImageService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _hotelImageService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByHotelImageId(int hotelImageId)
        {
            var result = _hotelImageService.GetById(hotelImageId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file,HotelImageAddDTO hotelImageAddDTO)
        {
            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            var result = _hotelImageService.Add(file, hotelImageAddDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete([FromForm(Name = ("Image"))] IFormFile formFile, HotelImageDeleteDTO hotelImageDeleteDTO)
        {
            var result = _hotelImageService.Delete(formFile, hotelImageDeleteDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile formFile, HotelImageUpdateDTO hotelImageUpdateDTP)
        {
            var result = _hotelImageService.Update(formFile,hotelImageUpdateDTP);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}