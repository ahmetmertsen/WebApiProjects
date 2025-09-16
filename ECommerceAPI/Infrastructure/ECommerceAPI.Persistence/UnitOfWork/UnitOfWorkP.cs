using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.UnitOfWork
{
    public class UnitOfWorkP : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;

        public IUserRepository UserRepository { get; }
        public IAddressRepository AddressRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IPaymentRepository PaymentRepository { get; }

        public UnitOfWorkP(ECommerceDbContext context, IUserRepository userRepository, IAddressRepository addressRepository, ICartRepository cartRepository, ICartItemRepository cartItemRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IPaymentRepository paymentRepository)
        {
            _context = context;
            UserRepository = userRepository;
            AddressRepository = addressRepository;
            CartRepository = cartRepository;
            CartItemRepository = cartItemRepository;
            OrderRepository = orderRepository;
            OrderItemRepository = orderItemRepository;
            ProductRepository = productRepository;
            PaymentRepository = paymentRepository;
        }

        public void Dispose() => _context.Dispose();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
    }
}
