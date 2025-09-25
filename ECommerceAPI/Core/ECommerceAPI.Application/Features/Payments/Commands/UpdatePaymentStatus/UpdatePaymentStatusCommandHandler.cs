using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Commands.UpdatePaymentStatus
{
    public class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommand, UpdatePaymentStatusCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdatePaymentStatusCommand> _validator;
        private readonly IMapper _mapper;

        public UpdatePaymentStatusCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdatePaymentStatusCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdatePaymentStatusCommandResponse> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(request.Id);
            if (payment == null)
            {
                //Exception yazılacak.
            }

            _mapper.Map(request, payment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<PaymentDto>(payment);
            return new UpdatePaymentStatusCommandResponse(response);
        }
    }
}
