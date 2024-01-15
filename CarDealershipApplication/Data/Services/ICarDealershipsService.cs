using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;

namespace CarDealershipApplication.Data.Services
{
    public interface ICarDealershipsService
    {
        Task AddCarDealershipAsync(CarDealershipVM carDealership);
        Task<List<CarDealership>> GetAllCarDealershipsAsync();
        Task<CarDealership> GetCarDealershipByIdAsync(int carDealershipId);
        Task<CarDealership> UpdateCarDealershipByIdAsync(int carDealershipId, CarDealershipVM carDealership);
        Task DeleteCarDealershipByIdAsync(int carDealershipId);
    }
}
