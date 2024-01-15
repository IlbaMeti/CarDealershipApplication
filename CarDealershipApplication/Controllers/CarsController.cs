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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCars()
        {
            var allCars = await _carService.GetAllCars();
            return Ok(allCars);
        }

        [HttpGet("get-by-Id/{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var carById = await _carService.GetCarById(id);
            return Ok(carById);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCar([FromBody] CarVM car)
        {
            await _carService.AddCar(car);
            return Ok();
        }

        [HttpPut("update-by-id/{id}")]
        public async Task<IActionResult> UpdateCarById(int id, [FromBody] CarVM car)
        {
            var updatedCar = await _carService.UpdateCarById(id, car);
            return Ok(updatedCar);
        }

        [HttpDelete("delete-by-id/{id}")]
        public async Task<IActionResult> DeleteCarById(int id)
        {
            await _carService.DeleteCarById(id);
            return Ok();
        }
    }
}
