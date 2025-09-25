using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Queries.GetAll
{
    public class GetAllAddressesRequestHandler : IRequestHandler<GetAllAddressesRequest,List<AddressDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAddressesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AddressDto>> Handle(GetAllAddressesRequest request, CancellationToken cancellationToken)
        {
            var addresses = await _unitOfWork.AddressRepository.GetAllAsync();
            var response =  _mapper.Map<List<AddressDto>>(addresses);
            return response;
        }
    }
}
