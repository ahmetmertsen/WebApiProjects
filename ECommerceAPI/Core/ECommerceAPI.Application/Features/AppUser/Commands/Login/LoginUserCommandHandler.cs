using ECommerceAPI.Domain.Entities.Identity;
using ECommerceAPI.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.AppUser.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user =  await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException("Kullanıcı adı veya şifre hatalı! Kullanıcı Bulunamadı...");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                //Yetkiler
            } else
            {
                throw new UnauthorizedAccessException("Kullanıcı adı veya şifre hatalı!");
            }
            return new LoginUserCommandResponse(true,"Giriş işlemi başarılı.");
        }
    }
}
