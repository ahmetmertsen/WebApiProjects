using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,UpdateProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateProductCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateProductCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var productEntity = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (productEntity == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Ürün bulunamadı...");
            }

            _mapper.Map(request, productEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var response = _mapper.Map<ProductDto>(productEntity);
            return new UpdateProductCommandResponse(response);
        }
    }
}
