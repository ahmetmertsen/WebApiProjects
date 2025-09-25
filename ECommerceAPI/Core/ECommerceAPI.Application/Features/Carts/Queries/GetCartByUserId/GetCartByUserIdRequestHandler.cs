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

namespace ECommerceAPI.Application.Features.Carts.Queries.GetCartByUserId
{
    public class GetCartByUserIdRequestHandler : IRequestHandler<GetCartByUserIdRequest,CartDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCartByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(GetCartByUserIdRequest request, CancellationToken cancellationToken)
        {
            var cartEntity = await _unitOfWork.CartRepository.GetByUserIdAsync(request.UserId);
            if (cartEntity == null)
            {
                throw new NotFoundException($"{request.UserId} Id'sine ait Kullanıcı bulunamadı...");
            }

            var response = _mapper.Map<CartDto>(cartEntity);
            return response;
        }
    }
}
