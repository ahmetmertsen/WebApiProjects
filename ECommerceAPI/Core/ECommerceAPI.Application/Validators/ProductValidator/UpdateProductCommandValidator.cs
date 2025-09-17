using ECommerceAPI.Application.Features.Products.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.ProductValidator
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ProductId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir ProductId girilmelidir");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün İsmi boş olmamalı!")
                .MinimumLength(2).WithMessage("Ürün İsmi en az 2 karekter olmalıdır!");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir ürün fiyatı girilmelidir");

            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok sayısı boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir stok sayısı girilmelidir");
        }
    }
}
