using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipApplication.Data.Services
{
    public class CarService:ICarsService
    {
        private AppDbContext _context;
        public CarService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCar(CarVM car)
        {
            var _car = new Car()
            {
               Model=car.Model,
               Color=car.Color,
               Year=car.Year,
               Price=car.Price,
               FuelType=car.FuelType,
               EngineType=car.EngineType,
               VIN=car.VIN
            };
            await _context.Cars.AddAsync(_car);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Car>> GetAllCars() => await _context.Cars.ToListAsync();
        public async Task<Car> GetCarById(int carId) => await _context.Cars.FirstOrDefaultAsync(n => n.Id == carId);
        public async Task<Car> UpdateCarById(int carId, CarVM car)
        {
            var _car = await _context.Cars.FirstOrDefaultAsync(n => n.Id == carId);
            if (_car != null)
            {
                _car.Model = car.Model;
                _car.Color = car.Color;
                _car.Year = car.Year;
                _car.Price = car.Year;
                _car.FuelType = car.FuelType;
                _car.EngineType = car.EngineType;
                _car.VIN = car.VIN;

                await _context.SaveChangesAsync();
            }
            return _car;
        }
        public async Task DeleteCarById(int carId)
        {
            var _car = await _context.Cars.FirstOrDefaultAsync(n => n.Id == carId);
            if (_car != null)
            {
                _context.Cars.Remove(_car);
                await _context.SaveChangesAsync();
            }
        }
    }
}

