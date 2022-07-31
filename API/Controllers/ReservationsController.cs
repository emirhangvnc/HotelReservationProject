using Business.Abstract;
using Entities.DTOs.Concrete.ReservationDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _reservationService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByReservationId(int reservationId)
        {
            var result = _reservationService.GetById(reservationId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(ReservationAddDTO reservationAddDTO)
        {
            var result = _reservationService.Add(reservationAddDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(ReservationDeleteDTO reservationDeleteDTO)
        {
            var result = _reservationService.Delete(reservationDeleteDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(ReservationUpdateDTO reservationUpdateDTP)
        {
            var result = _reservationService.Update(reservationUpdateDTP);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}