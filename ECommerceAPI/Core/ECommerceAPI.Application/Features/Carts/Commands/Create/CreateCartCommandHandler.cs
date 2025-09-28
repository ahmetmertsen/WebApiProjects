using AutoMapper;
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

namespace ECommerceAPI.Application.Features.Carts.Commands.Create
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CreateCartCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCartCommand> _validator;

        public CreateCartCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCartCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateCartCommandResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new NotFoundException($"{request.CustomerId} Id'sine ait Müşteri bulunamadı...");
            }

            var cartEntity = _mapper.Map<Cart>(request);
            await _unitOfWork.CartRepository.AddAsync(cartEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CreateCartCommandResponse>(cartEntity);
            return response;
        }
    }
}
