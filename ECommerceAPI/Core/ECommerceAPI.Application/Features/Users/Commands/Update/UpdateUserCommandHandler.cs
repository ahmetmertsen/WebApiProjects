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

namespace ECommerceAPI.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,UpdateUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateUserCommand> _validator;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateUserCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var userEntity = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (userEntity == null)
            {
                //Exception yazılacak
            }

            _mapper.Map(request, userEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var userDto = _mapper.Map<UserDto>(userEntity);
            return new UpdateUserCommandResponse(userDto);
        }
    }
}
