using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;

namespace CarDealershipApplication.Data.Services
{
    public interface ICarDealershipsService
    {
        Task AddCarDealership(CarDealershipVM carDealership);
        Task<List<CarDealership>> GetAllCarDealerships();
        Task<CarDealership> GetCarDealershipById(int carDealershipId);
        Task<CarDealership> UpdateCarDealershipById(int carDealershipId, CarDealershipVM carDealership);
        Task DeleteCarDealershipById(int carDealershipId);
    }
}
