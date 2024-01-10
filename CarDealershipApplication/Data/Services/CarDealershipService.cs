using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.ViewModels;

namespace CarDealershipApplication.Data.Services
{
    public class CarDealershipService
    {
        private AppDbContext _context;
        public CarDealershipService(AppDbContext context)
        {
            _context = context;
        }
        public void AddCarDealership(CarDealershipVM carDealership)
        {
            var _carDealership = new CarDealership()
            {
                DealershipName = carDealership.DealershipName,
                Location = carDealership.Location,
                DealerLicenseNumber = carDealership.DealershipName,
                ContactNumber = carDealership.ContactNumber,
                Email = carDealership.Email
            };
            _context.CarDealerships.Add(_carDealership);
            _context.SaveChanges();
        }
        public List<CarDealership> GetAllCarDealerships() => _context.CarDealerships.ToList();
        public CarDealership GetCarDealershipById(int carDealershipId) => _context.CarDealerships.FirstOrDefault(n => n.Id == carDealershipId);
        public CarDealership UpdateCarDealershipById(int carDealershipId ,CarDealershipVM carDealership)
        {
            var _carDealership = _context.CarDealerships.FirstOrDefault(n => n.Id == carDealershipId);
            if(_carDealership != null )
            {
                _carDealership.DealershipName = carDealership.DealershipName;
                _carDealership.Location = carDealership.Location;
                _carDealership.DealerLicenseNumber = carDealership.DealershipName;
                _carDealership.ContactNumber = carDealership.ContactNumber;
                _carDealership.Email = carDealership.Email;

                _context.SaveChanges();
            }
            return _carDealership;
        }
        public void DeleteCarDealershipById(int carDealershipId)
        {
            var _carDealership = _context.CarDealerships.FirstOrDefault(n => n.Id == carDealershipId);
            if(_carDealership != null ) 
            {
                _context.CarDealerships.Remove(_carDealership);
                _context.SaveChanges();
            }
        }
    }
}
