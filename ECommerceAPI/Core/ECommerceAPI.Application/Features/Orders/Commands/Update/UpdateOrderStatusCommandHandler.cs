using AutoMapper;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Orders.Commands.Update
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, UpdateOrderStatusCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateOrderStatusCommand> _validator;
        private readonly IMapper _mapper;
        
        public UpdateOrderStatusCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateOrderStatusCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateOrderStatusCommandResponse> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Sipariş bulunamadı...");
            }

            _mapper.Map(request, order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateOrderStatusCommandResponse(order.Id, order.Status);
        }
    }
}
