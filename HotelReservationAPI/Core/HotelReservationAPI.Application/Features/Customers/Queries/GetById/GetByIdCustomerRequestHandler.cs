using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Customers.Queries.GetById
{
    public class GetByIdCustomerRequestHandler : IRequestHandler<GetByIdCustomerRequest, CustomerDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdCustomerRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetByIdCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customer == null) 
            {
                //Exception yazılacak.
            }
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
