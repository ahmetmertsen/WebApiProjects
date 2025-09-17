using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Payments.Commands.Create;
using ECommerceAPI.Application.Features.Payments.Commands.UpdatePaymentStatus;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.PaymentMapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile() 
        {
            CreateMap<CreatePaymentCommand, Payment>();
            CreateMap<UpdatePaymentStatusCommand, Payment>();

            CreateMap<Payment, PaymentDto>();

            CreateMap<Payment, CreatePaymentCommandResponse>();
            CreateMap<Payment, UpdatePaymentStatusCommandResponse>();
        }
    }
}
