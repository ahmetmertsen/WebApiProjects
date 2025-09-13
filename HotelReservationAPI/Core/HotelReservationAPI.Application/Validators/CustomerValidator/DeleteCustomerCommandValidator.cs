using FluentValidation;
using HotelReservationAPI.Application.Features.Customers.Commands.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.CustomerValidator
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("CustomerId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir CustomerId girilmelidir");
        }
    }
}
