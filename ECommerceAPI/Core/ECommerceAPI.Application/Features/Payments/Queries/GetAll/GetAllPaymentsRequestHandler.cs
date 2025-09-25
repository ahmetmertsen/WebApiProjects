using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Queries.GetAll
{
    public class GetAllPaymentsRequestHandler : IRequestHandler<GetAllPaymentsRequest, List<PaymentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPaymentsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PaymentDto>> Handle(GetAllPaymentsRequest request, CancellationToken cancellationToken)
        {
            var payments = await _unitOfWork.PaymentRepository.GetAllAsync();
            var response = _mapper.Map<List<PaymentDto>>(payments);
            return response;
        }
    }
}
