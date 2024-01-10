using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;

namespace CarDealershipApplication.Data.Services
{
    public class CarService
    {
        private AppDbContext _context;
        public CarService(AppDbContext context)
        {
            _context = context;
        }
        public void AddCar(CarVM car)
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
            _context.Cars.Add(_car);
            _context.SaveChanges();
        }
        public List<Car> GetAllCars() => _context.Cars.ToList();
        public Car GetCarById(int carId) => _context.Cars.FirstOrDefault(n => n.Id == carId);
        public Car UpdateCarById(int carId, CarVM car)
        {
            var _car = _context.Cars.FirstOrDefault(n => n.Id == carId);
            if (_car != null)
            {
                _car.Model = car.Model;
                _car.Color = car.Color;
                _car.Year = car.Year;
                _car.Price = car.Year;
                _car.FuelType = car.FuelType;
                _car.EngineType = car.EngineType;
                _car.VIN = car.VIN;

                _context.SaveChanges();
            }
            return _car;
        }
        public void DeleteCarById(int carId)
        {
            var _car = _context.Cars.FirstOrDefault(n => n.Id == carId);
            if (_car != null)
            {
                _context.Cars.Remove(_car);
                _context.SaveChanges();
            }
        }
    }
}

