using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.Services;
using CarDealershipApplication.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDealershipsController : ControllerBase
    {
        public CarDealershipService _carDealershipService;
        public CarDealershipsController(CarDealershipService carDealershipService)
        {
            _carDealershipService = carDealershipService;
        }

        [HttpGet("get-all-carDealerships")]
        public IActionResult GetAllCarDealerships() 
        {
            var allCarDealerships= _carDealershipService.GetAllCarDealerships();
            return Ok(allCarDealerships);
        }

        [HttpGet("get-carDealership-by-Id/{id}")]
        public IActionResult GetCarDealershipById(int id)
        {
            var carDealershipById = _carDealershipService.GetCarDealershipById(id);
            return Ok(carDealershipById);
        }

        [HttpPost("add-carDealership")]
        public IActionResult AddCarDealership([FromBody]CarDealershipVM carDealership)
        {
            _carDealershipService.AddCarDealership(carDealership);
            return Ok();
        }

        [HttpPut("update-carDealership-by-id/{id}")]
        public IActionResult UpdateCarDealershipById(int id, [FromBody]CarDealershipVM carDealership)
        {
            var updatedCarDealership=_carDealershipService.UpdateCarDealershipById(id, carDealership);
            return Ok(updatedCarDealership);
        }

        [HttpDelete("delete-carDealership-by-id/{id}")]
        public IActionResult DeleteCarDealershipById(int id)
        {
            _carDealershipService.DeleteCarDealershipById(id);
            return Ok();
        }

    }
}
