
using CarDealershipApplication.Data;
using CarDealershipApplication.Data.Models;
using CarDealershipApplication.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Configure AppDbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=ILBA\\SQLEXPRESS;Initial Catalog=CarDealership-db;Integrated Security=True;Pooling=False"));

                options.UseSqlServer("Data Source=ILBA\\SQLEXPRESS;Initial Catalog=CarDealership-db;Integrated Security=True;Pooling=False;TrustServerCertificate=true");
            });

            // Configure Services
            builder.Services.AddScoped<ICarDealershipsService , CarDealershipService>();
            builder.Services.AddScoped<ICarsService , CarService>();


            var app = builder.Build();

            // Seed the database
            AppDbInitializer.Seed(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}