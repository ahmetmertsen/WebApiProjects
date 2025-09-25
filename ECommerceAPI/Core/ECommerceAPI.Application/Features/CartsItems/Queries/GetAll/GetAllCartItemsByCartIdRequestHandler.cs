using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Queries.GetAll
{
    public class GetAllCartItemsByCartIdRequestHandler : IRequestHandler<GetAllCartItemsByCartIdRequest,List<CartItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCartItemsByCartIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CartItemDto>> Handle(GetAllCartItemsByCartIdRequest request, CancellationToken cancellationToken)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(request.CartId);
            if (cart == null)
            {
                //Exception yazılacak
            }

            var cartItems = await _unitOfWork.CartItemRepository.GetAllByCartIdAsync(cart.Id);
            var response = _mapper.Map<List<CartItemDto>>(cartItems);
            return response;
        }

    }
}
