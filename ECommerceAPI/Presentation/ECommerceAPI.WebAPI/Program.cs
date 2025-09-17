using ECommerceAPI.Application.Features.Users.Commands.Create;
using ECommerceAPI.Application.Mapping.UserMapper;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Validators.UserValidator;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Extensions;
using ECommerceAPI.Persistence.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.WebAPI
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


            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssemblyContaining<CreateUserCommand>());
            builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);


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
