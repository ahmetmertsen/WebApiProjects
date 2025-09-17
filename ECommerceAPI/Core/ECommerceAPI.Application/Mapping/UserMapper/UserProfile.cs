using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Users.Commands.Create;
using ECommerceAPI.Application.Features.Users.Commands.Update;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.UserMapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            CreateMap<User, UserDto>();

            CreateMap<User, CreateUserCommandResponse>();
            CreateMap<User, UpdateUserCommandResponse>();
        }
    }
}
