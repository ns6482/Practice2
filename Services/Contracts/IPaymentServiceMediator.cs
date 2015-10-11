using System;
using TheTicketSellers.Dto;
using TheTicketSellers.Infrastructure.Service;

namespace TheTicketSellers.Services.Contracts
{
    public interface IPaymentServiceMediator : IDisposable
    {
        PaymentServiceMediatorBillResult Bill(PaymentDto dto);
    }
}