using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Commands.Create
{
    public record CreatePaymentCommandResponse(int Id, int OrderId, PaymentStatus Status, PaymentMethod PaymentMethod, decimal Amount)
    {
    }
}
