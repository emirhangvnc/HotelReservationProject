using Business.Abstract;
using Entities.DTOs.Concrete.CityDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _cityService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByCityId(int cityId)
        {
            var result = _cityService.GetById(cityId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(CityAddDTO cityAddDTO)
        {
            var result = _cityService.Add(cityAddDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(CityDeleteDTO cityDeleteDTO)
        {
            var result = _cityService.Delete(cityDeleteDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(CityUpdateDTO cityUpdateDTP)
        {
            var result = _cityService.Update(cityUpdateDTP);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}