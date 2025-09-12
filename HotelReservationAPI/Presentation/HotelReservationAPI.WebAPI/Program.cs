using HotelReservationAPI.Application.Repositories;
using HotelReservationAPI.Application.UnitOfWork;
using HotelReservationAPI.Persistence;
using HotelReservationAPI.Persistence.Contexts;
using HotelReservationAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationAPI.WebAPI
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

            builder.Services.AddDbContext<HotelReservationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

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
