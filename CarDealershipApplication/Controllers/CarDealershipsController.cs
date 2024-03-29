﻿using CarDealershipApplication.Data.Models;
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
        public ICarDealershipsService _carDealershipService;
        public CarDealershipsController(ICarDealershipsService carDealershipService)
        {
            _carDealershipService = carDealershipService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCarDealerships() 
        {
            var allCarDealerships= await _carDealershipService.GetAllCarDealershipsAsync();
            return Ok(allCarDealerships);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetCarDealershipById(int id)
        {
            var carDealershipById = await _carDealershipService.GetCarDealershipByIdAsync(id);
            return Ok(carDealershipById);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCarDealership([FromBody]CarDealershipVM carDealership)
        {
            await _carDealershipService.AddCarDealershipAsync(carDealership);
            return Ok();
        }

        [HttpPut("update-by-id/{id}")]
        public async Task<IActionResult> UpdateCarDealershipById(int id, [FromBody]CarDealershipVM carDealership)
        {
            var updatedCarDealership=await _carDealershipService.UpdateCarDealershipByIdAsync(id, carDealership);
            return Ok(updatedCarDealership);
        }

        [HttpDelete("delete-by-id/{id}")]
        public async Task<IActionResult> DeleteCarDealershipById(int id)
        {
            await _carDealershipService.DeleteCarDealershipByIdAsync(id);
            return Ok();
        }

    }
}
