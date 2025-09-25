using AutoMapper;
using ECommerceAPI.Application.UnitOfWork;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Products.Commands.UpdateStock
{
    public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, UpdateProductStockCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateProductStockCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateProductStockCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateProductStockCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateProductStockCommandResponse> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var productEntity = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (productEntity == null)
            {
                //Exception yazılacak
            }

            _mapper.Map(request, productEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateProductStockCommandResponse(productEntity.Id, productEntity.Stock);
        }
    }
}
