using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories;
using ECommerceAPI.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services) {

            services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql("DefaultConnection"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWorkP>();

            return services;
        }
    }
}
