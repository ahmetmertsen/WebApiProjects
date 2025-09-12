using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Dtos;
using UserManagementAPI.Application.Features.Users.Commands.Create;
using UserManagementAPI.Application.Features.Users.Commands.Update;
using UserManagementAPI.Domain.Entities;

namespace UserManagementAPI.Application.Mapping.UserMapper
{
    public class UserProfile : Profile
    {

        public UserProfile() 
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDto>();
        }
    }
}
