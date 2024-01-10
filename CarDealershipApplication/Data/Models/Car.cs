namespace CarDealershipApplication.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
        public string EngineType { get; set; }
        public string VIN { get; set; } // Vehicle Identification Number
    }
}
