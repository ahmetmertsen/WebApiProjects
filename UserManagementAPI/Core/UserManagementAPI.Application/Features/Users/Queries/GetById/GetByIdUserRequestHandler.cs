using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Dtos;
using UserManagementAPI.Application.UnitOfWork;

namespace UserManagementAPI.Application.Features.Users.Queries.GetById
{
    public class GetByIdUserRequestHandler : IRequestHandler<GetByIdUserRequest, UserDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetByIdUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetByIdUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
