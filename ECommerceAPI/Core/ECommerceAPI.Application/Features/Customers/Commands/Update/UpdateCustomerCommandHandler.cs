using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand,UpdateCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateCustomerCommand> _validator;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateCustomerCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var customerEntity = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customerEntity == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Müşteri bulunamadı...");
            }

            _mapper.Map(request, customerEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var customerDto = _mapper.Map<CustomerDto>(customerEntity);
            return new UpdateCustomerCommandResponse(customerDto);
        }
    }
}
