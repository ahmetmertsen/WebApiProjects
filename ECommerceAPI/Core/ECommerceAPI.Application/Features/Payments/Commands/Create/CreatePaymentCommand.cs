using ECommerceAPI.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Commands.Create
{
    public record CreatePaymentCommand(int OrderId, PaymentMethod PaymentMethod) : IRequest<CreatePaymentCommandResponse>
    {
    }
}
