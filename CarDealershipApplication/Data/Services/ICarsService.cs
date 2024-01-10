using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;

namespace CarDealershipApplication.Data.Services
{
    public interface ICarsService
    {
        Task AddCar(CarVM car);
        Task<List<Car>> GetAllCars();
        Task<Car> GetCarById(int carId);
        Task<Car> UpdateCarById(int carId, CarVM car);
        Task DeleteCarById(int carId);
    }
}
