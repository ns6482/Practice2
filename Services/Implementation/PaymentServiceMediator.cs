using System;
using TheTicketSellers.Dto;
using TheTicketSellers.Infrastructure.Service;
using TheTicketSellers.Services.Contracts;

namespace TheTicketSellers.Services.Implementation
{
    /// <summary>
    ///     The language we use in our domain is different to payment service,
    ///     assuming it is a legacy product. To prevent this logic "corrupting"
    ///     our domain a mediator like this can act like a "translator",
    ///     a go between if you like. For e.g. the payment service returns just a
    ///     a string once a payment is made, assume we need to translate this into
    ///     a meaningul, for e.g. a code could be returned to determine a success.
    ///     This will stop such weird logic polluting our domain
    /// </summary>
    public class PaymentServiceMediator : IPaymentServiceMediator
    {
        /// <summary>
        ///     The _payment service
        /// </summary>
        private readonly IPaymentService _paymentService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PaymentServiceMediator" /> class.
        /// </summary>
        /// <param name="paymentService">The payment service.</param>
        public PaymentServiceMediator(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        ///     Bills the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public PaymentServiceMediatorBillResult Bill(PaymentDto dto)
        {
            var result = _paymentService.Bill(dto.Customer, dto.Amount, dto.Card);

            var pr = new PaymentServiceMediatorBillResult
            {
                Data = result,
                Status = Status.Ok
            };

            return pr;
            //not sure what string would result in success/failure, probably some condition here
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            _paymentService.Dispose();
        }
    }
}