using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Commands.Update
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand,UpdateAddressCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateAddressCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateAddressCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var addressEntity = await _unitOfWork.AddressRepository.GetByIdAsync(request.Id);
            if (addressEntity == null)
            {
                //Exception yazılacak.
            }

            _mapper.Map(request,addressEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var addressDto = _mapper.Map<AddressDto>(addressEntity);
            return new UpdateAddressCommandResponse(addressDto);
        }
    }
}
