using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.UnitOfWork;
using UserManagementAPI.Domain.Entities;

namespace UserManagementAPI.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateUserCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var userEntity = _mapper.Map<User>(request);
            await _unitOfWork.UserRepository.AddAsync(userEntity);
            var response = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return response > 0;
        }
    }
}
