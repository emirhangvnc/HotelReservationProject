using Business.Abstract;
using Entities.DTOs.Concrete.CountryDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _countryService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByCountryId(int countryId)
        {
            var result = _countryService.GetById(countryId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(CountryAddDTO countryAddDTO)
        {
            var result = _countryService.Add(countryAddDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(CountryDeleteDTO countryDeleteDTO)
        {
            var result = _countryService.Delete(countryDeleteDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(CountryUpdateDTO countryUpdateDTP)
        {
            var result = _countryService.Update(countryUpdateDTP);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}