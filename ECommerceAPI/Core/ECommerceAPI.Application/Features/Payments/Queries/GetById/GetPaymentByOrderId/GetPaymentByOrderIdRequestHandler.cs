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

namespace ECommerceAPI.Application.Features.Payments.Queries.GetById.GetPaymentByOrderId
{
    public class GetPaymentByOrderIdRequestHandler : IRequestHandler<GetPaymentByOrderIdRequest, PaymentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPaymentByOrderIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaymentDto> Handle(GetPaymentByOrderIdRequest request, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.PaymentRepository.GetPaymentByOrderIdAsync(request.OrderId);
            if (payment == null)
            {
                throw new NotFoundException($"{request.OrderId} Id'sine ait Ödeme bulunamadı...");
            }

            var response = _mapper.Map<PaymentDto>(payment);
            return response;
        }
    }
}
