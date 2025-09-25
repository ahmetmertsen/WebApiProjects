using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Payments.Queries.GetById.GetPaymentByOrderId;
using ECommerceAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Queries.GetById.GetPaymentById
{
    public class GetPaymentByIdRequestHandler : IRequestHandler<GetPaymentByIdRequest, PaymentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPaymentByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaymentDto> Handle(GetPaymentByIdRequest request, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(request.Id);
            if (payment == null)
            {
                //Exception yazılacak.
            }

            var response = _mapper.Map<PaymentDto>(payment);
            return response;
        }
    }
}
