using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Queries.GetById
{
    public class GetByIdCartItemRequestHandler : IRequestHandler<GetByIdCartItemRequest,CartItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdCartItemRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartItemDto> Handle(GetByIdCartItemRequest request, CancellationToken cancellationToken)
        {
            var cartItem = await _unitOfWork.CartItemRepository.GetByIdAsync(request.Id);
            if (cartItem == null)
            {
                //Exception yazılacak.
            }

            var response = _mapper.Map<CartItemDto>(cartItem);
            return response;
        }
    }
}
