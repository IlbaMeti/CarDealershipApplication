using CarDealershipApplication.Data.Services;
using CarDealershipApplication.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public CarService _carService;
        public CarsController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet("get-all-cars")]
        public IActionResult GetAllCars()
        {
            var allCars = _carService.GetAllCars();
            return Ok(allCars);
        }

        [HttpGet("get-car-by-Id/{id}")]
        public IActionResult GetCarById(int id)
        {
            var carById = _carService.GetCarById(id);
            return Ok(carById);
        }

        [HttpPost("add-car")]
        public IActionResult AddCar([FromBody] CarVM car)
        {
            _carService.AddCar(car);
            return Ok();
        }

        [HttpPut("update-car-by-id/{id}")]
        public IActionResult UpdateCarById(int id, [FromBody] CarVM car)
        {
            var updatedCar = _carService.UpdateCarById(id, car);
            return Ok(updatedCar);
        }

        [HttpDelete("delete-car-by-id/{id}")]
        public IActionResult DeleteCarById(int id)
        {
            _carService.DeleteCarById(id);
            return Ok();
        }
    }
}
