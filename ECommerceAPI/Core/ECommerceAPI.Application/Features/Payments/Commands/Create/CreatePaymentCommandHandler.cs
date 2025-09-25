using AutoMapper;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Enum;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Commands.Create
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreatePaymentCommand> _validator;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(IUnitOfWork unitOfWork, IValidator<CreatePaymentCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);
            if (order == null)
            {
                //Exception yazılacak.
            }

            var paymentEntity = _mapper.Map<Payment>(request);
            paymentEntity.Status = PaymentStatus.Pending;
            await _unitOfWork.PaymentRepository.AddAsync(paymentEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CreatePaymentCommandResponse>(paymentEntity);
            return response;
        }
    }
}
