using CarDealershipApplication.Data.Models;

namespace CarDealershipApplication.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using (var serviceScope=applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                
                if (!context.CarDealerships.Any()) 
                {
                    context.CarDealerships.AddRange(new CarDealership()
                    {
                        DealershipName = "ABC Auto Sales",
                        Location = "123 Main Street",
                        DealerLicenseNumber = "DL123456",
                        ContactNumber = "+1 (555) 123-4567",
                        Email = "info@abcautosales.com"
                    },
                    new CarDealership() 
                    {
                        DealershipName = "XYZ Motors",
                        Location = "456 Oak Avenue",
                        DealerLicenseNumber = "DL654321",
                        ContactNumber = "+1 (555) 987-6543",
                        Email = "info@xyzmotors.com"
                    },
                    new CarDealership()
                    {
                        DealershipName = "123 Auto World",
                        Location = "789 Pine Street",
                        DealerLicenseNumber = "DL789012",
                        ContactNumber = "+1 (555) 789-0123",
                        Email = "info@123autoworld.com"
                    },
                    new CarDealership()
                    {
                        DealershipName = "Best Cars Inc.",
                        Location = "321 Elm Avenue",
                        DealerLicenseNumber = "DL345678",
                        ContactNumber = "+1 (555) 456-7890",
                        Email = "info@bestcarsinc.com"
                    });
                    context.SaveChanges();
                }
                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new Car()
                    {
                        Model = "Toyota Camry",
                        Color = "Blue",
                        Year = 2022,
                        Price = 25000.00m,
                        FuelType = "Gasoline",
                        EngineType = "V6",
                        VIN = "1ABC23456789DEF01"
                    },
                    new Car()
                    {
                        Model = "Honda Accord",
                        Color = "Red",
                        Year = 2021,
                        Price = 22000.00m,
                        FuelType = "Hybrid",
                        EngineType = "Inline-4",
                        VIN = "2XYZ34567890ABC12"
                    },
                    new Car()
                    {
                        Model = "Ford Mustang",
                        Color = "Black",
                        Year = 2023,
                        Price = 35000.00m,
                        FuelType = "Gasoline",
                        EngineType = "V8",
                        VIN = "3DEF45678901GHI23"
                    },
                    new Car()
                    {
                        Model = "Tesla Model 3",
                        Color = "White",
                        Year = 2022,
                        Price = 45000.00m,
                        FuelType = "Electric",
                        EngineType = "Electric Motor",
                        VIN = "5JKL67890123MNO45"
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
