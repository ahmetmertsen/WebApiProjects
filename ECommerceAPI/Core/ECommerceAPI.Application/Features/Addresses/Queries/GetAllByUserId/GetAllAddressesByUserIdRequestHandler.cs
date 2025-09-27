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

namespace ECommerceAPI.Application.Features.Addresses.Queries.GetAllByUserId
{
    public class GetAllAddressesByUserIdRequestHandler : IRequestHandler<GetAllAddressesByUserIdRequest, List<AddressDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAddressesByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AddressDto>> Handle(GetAllAddressesByUserIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.userId);
            if (user == null)
            {
                throw new NotFoundException($"{request.userId} Id'sine ait Kullanıcı bulunamadı...");
            }

            var addresses = await _unitOfWork.AddressRepository.GetAllByUserIdAsync(user.Id);
            if (addresses == null)
            {
                throw new NotFoundException($"{user.Id} Id'sine ait Adres bulunamadı...");
            }
            var response = _mapper.Map<List<AddressDto>>(addresses);
            return response;
        }
    }
}
