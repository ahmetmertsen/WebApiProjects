using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Commands.UpdatePaymentMethod.FailPaymentCommand
{
    public record UpdateFailPaymentCommandResponse(int Id, PaymentStatus Status = PaymentStatus.Failed)
    {
    }
}
