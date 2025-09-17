using ECommerceAPI.Application.Features.Addresses.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.AddressValidator
{
    public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir Id girilmelidir");
        }
    }
}
