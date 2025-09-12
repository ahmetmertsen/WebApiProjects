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

namespace UserManagementAPI.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
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

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var userEntity = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (userEntity == null) 
            {
                throw new Exception("User not found");
            }
            _mapper.Map(request, userEntity);
            var response = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return response > 0;
        }
    }
}
