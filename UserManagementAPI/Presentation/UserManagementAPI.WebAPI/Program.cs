using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserManagementAPI.Application.Features.Users.Commands.Create;
using UserManagementAPI.Application.Features.Users.Commands.Update;
using UserManagementAPI.Application.Mapping.UserMapper;
using UserManagementAPI.Application.Repositories;
using UserManagementAPI.Application.UnitOfWork;
using UserManagementAPI.Application.Validators.UserValidator;
using UserManagementAPI.Persistence.Contexts;
using UserManagementAPI.Persistence.Repositories;
using UserManagementAPI.Persistence.UnitOfWork;

namespace UserManagementAPI.WebAPI
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

            builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining<CreateUserCommandHandler>());
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();


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
