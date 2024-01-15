using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;

namespace CarDealershipApplication.Data.Services
{
    public interface ICarsService
    {
        Task AddCarAsync(CarVM car);
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int carId);
        Task<Car> UpdateCarByIdAsync(int carId, CarVM car);
        Task DeleteCarByIdAsync(int carId);
    }
}
