using AutoMapper;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.AppUser.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.UserName = request.Email;
            user.Email = request.Email;

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded == true)
            {
                var customer = new Customer() { 
                    FullName = request.FullName, 
                    UserId = user.Id 
                };

                await _unitOfWork.CustomerRepository.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new CreateUserCommandResponse(true,"Kullanıcı başarıyla kayıt olmuştur.");
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new CreateUserFailedException($"Kayıt sırasında hata oluştu. {errors}");
            }
                
        }
    }
}
