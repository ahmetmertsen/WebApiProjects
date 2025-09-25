using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrdersByUserIdRequestHandler : IRequestHandler<GetAllOrdersByUserIdRequest, List<OrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersByUserIdRequest request, CancellationToken cancellationToken)
        {
            var user =  await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException($"{request.UserId} Id'sine ait Kullanıcı bulunamadı...");
            }

            var orders = _unitOfWork.OrderRepository.GetAllOrdersByUserIdAsync(user.Id);
            var response =  _mapper.Map<List<OrderDto>>(orders);
            return response;
        }
    }
}
