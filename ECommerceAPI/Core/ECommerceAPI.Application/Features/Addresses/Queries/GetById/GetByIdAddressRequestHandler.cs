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

namespace ECommerceAPI.Application.Features.Addresses.Queries.GetById
{
    public class GetByIdAddressRequestHandler : IRequestHandler<GetByIdAddressRequest, AddressDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdAddressRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddressDto> Handle(GetByIdAddressRequest request, CancellationToken cancellationToken)
        {
            var address =  await _unitOfWork.AddressRepository.GetByIdAsync(request.Id);
            if (address == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Adres bulunamadı...");
            }

            var response =  _mapper.Map<AddressDto>(address);
            return response;
        }
    }
}
