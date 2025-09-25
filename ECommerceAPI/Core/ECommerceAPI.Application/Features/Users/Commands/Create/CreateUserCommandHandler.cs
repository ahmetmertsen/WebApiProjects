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

namespace ECommerceAPI.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var userEmail = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);
            if (userEmail != null)
            {
                throw new NotFoundException("Email Mevcut...");
            }

            var userEntity = _mapper.Map<User>(request);

            await _unitOfWork.UserRepository.AddAsync(userEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CreateUserCommandResponse>(userEntity);
            return response;

        }
    }
}
