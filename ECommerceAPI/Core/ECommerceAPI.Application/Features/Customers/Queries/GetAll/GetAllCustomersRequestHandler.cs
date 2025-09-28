using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomersRequestHandler : IRequestHandler<GetAllCustomersRequest, List<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomersRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var response = _mapper.Map<List<CustomerDto>>(customers);
            return response;
        }
    }
}
