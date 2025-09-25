using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Users.Queries.GetById
{
    public class GetByIdUserRequestHandler : IRequestHandler<GetByIdUserRequest,UserDto>
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
            if (user == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Kullanıcı bulunamadı...");
            }
            var response = _mapper.Map<UserDto>(user);
            return response;
        }
    }
}
