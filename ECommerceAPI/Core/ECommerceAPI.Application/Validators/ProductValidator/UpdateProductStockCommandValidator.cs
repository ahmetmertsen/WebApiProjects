using ECommerceAPI.Application.Features.Products.Commands.UpdateStock;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.ProductValidator
{
    public class UpdateProductStockCommandValidator : AbstractValidator<UpdateProductStockCommand>
    {
        public UpdateProductStockCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ProductId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir ProductId girilmelidir");

            RuleFor(x => x.NewStock).NotEmpty().WithMessage("Stok adet sayısı boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir stok adet sayısı girilmelidir");
        }
    }
}
