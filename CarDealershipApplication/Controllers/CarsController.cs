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
        public ICarsService _carService;
        public CarsController(ICarsService carService)
        {
            _carService = carService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCars()
        {
            var allCars = await _carService.GetAllCarsAsync();
            return Ok(allCars);
        }

        [HttpGet("get-by-Id/{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var carById = await _carService.GetCarByIdAsync(id);
            return Ok(carById);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCar([FromBody] CarVM car)
        {
            await _carService.AddCarAsync(car);
            return Ok();
        }

        [HttpPut("update-by-id/{id}")]
        public async Task<IActionResult> UpdateCarById(int id, [FromBody] CarVM car)
        {
            var updatedCar = await _carService.UpdateCarByIdAsync(id, car);
            return Ok(updatedCar);
        }

        [HttpDelete("delete-by-id/{id}")]
        public async Task<IActionResult> DeleteCarById(int id)
        {
            await _carService.DeleteCarByIdAsync(id);
            return Ok();
        }
    }
}
