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

namespace ECommerceAPI.Application.Features.Addresses.Queries.GetAllCustomerId
{
    public class GetAllAddressesByCustomerIdRequestHandler : IRequestHandler<GetAllAddressesByCustomerIdRequest, List<AddressDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAddressesByCustomerIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AddressDto>> Handle(GetAllAddressesByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new NotFoundException($"{request.CustomerId} Id'sine ait Müşteri bulunamadı...");
            }

            var addresses = await _unitOfWork.AddressRepository.GetAllByCustomerIdAsync(customer.Id);
            if (addresses == null)
            {
                throw new NotFoundException($"{customer.Id} Id'sine ait Adres bulunamadı...");
            }
            var response = _mapper.Map<List<AddressDto>>(addresses);
            return response;
        }
    }
}
