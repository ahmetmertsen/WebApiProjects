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

namespace ECommerceAPI.Application.Features.Carts.Queries.GetCartByCustomerId
{
    public class GetCartByCustomerIdRequestHandler : IRequestHandler<GetCartByCustomerIdRequest, CartDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCartByCustomerIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(GetCartByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            var cartEntity = await _unitOfWork.CartRepository.GetByCustomerIdAsync(request.CustomerId);
            if (cartEntity == null)
            {
                throw new NotFoundException($"{request.CustomerId} Id'sine ait Müşteri bulunamadı...");
            }

            var response = _mapper.Map<CartDto>(cartEntity);
            return response;
        }
    }
}
