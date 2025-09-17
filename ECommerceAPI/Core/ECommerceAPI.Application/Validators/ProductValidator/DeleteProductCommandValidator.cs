using ECommerceAPI.Application.Features.Products.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.ProductValidator
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ProductId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir ProductId girilmelidir");
        }
    }
}
