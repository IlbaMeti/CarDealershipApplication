using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipApplication.Data.Services
{
    public class CarDealershipService:ICarDealershipsService
    {
        private AppDbContext _context;
        public CarDealershipService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCarDealership(CarDealershipVM carDealership)
        {
            var _carDealership = new CarDealership()
            {
                DealershipName = carDealership.DealershipName,
                Location = carDealership.Location,
                DealerLicenseNumber = carDealership.DealershipName,
                ContactNumber = carDealership.ContactNumber,
                Email = carDealership.Email
            };
            await _context.CarDealerships.AddAsync(_carDealership);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CarDealership>> GetAllCarDealerships() => await _context.CarDealerships.ToListAsync();
        public async Task<CarDealership> GetCarDealershipById(int carDealershipId) => await _context.CarDealerships.FirstOrDefaultAsync(n => n.Id == carDealershipId);
        public async Task<CarDealership> UpdateCarDealershipById(int carDealershipId ,CarDealershipVM carDealership)
        {
            var _carDealership = await _context.CarDealerships.FirstOrDefaultAsync(n => n.Id == carDealershipId);
            if(_carDealership != null )
            {
                _carDealership.DealershipName = carDealership.DealershipName;
                _carDealership.Location = carDealership.Location;
                _carDealership.DealerLicenseNumber = carDealership.DealershipName;
                _carDealership.ContactNumber = carDealership.ContactNumber;
                _carDealership.Email = carDealership.Email;

                await _context.SaveChangesAsync();
            }
            return _carDealership;
        }
        public async Task DeleteCarDealershipById(int carDealershipId)
        {
            var _carDealership = await _context.CarDealerships.FirstOrDefaultAsync(n => n.Id == carDealershipId);
            if(_carDealership != null ) 
            {
                _context.CarDealerships.Remove(_carDealership);
                await _context.SaveChangesAsync();
            }
        }
    }
}
