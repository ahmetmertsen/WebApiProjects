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

namespace ECommerceAPI.Application.Features.Orders.Queries.GetById
{
    public class GetByIdOrderRequestHandler : IRequestHandler<GetByIdOrderRequest, OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdOrderRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetByIdOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdOrderWithItemsAsync(request.Id);
            if (order == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Sepet bulunamadı...");
            }

            var response = _mapper.Map<OrderDto>(order);
            return response;
        }

    }
}
