using TheTicketSellers.Dto;
using TheTicketSellers.Events;
using TheTicketSellers.Infrastructure.Domain;
using TheTicketSellers.Services.Contracts;

namespace TheTicketSellers.Services.EventHandlers
{
    /// <summary>
    ///     When an order is made , fire off payment. Makes sense that when order is successfuly
    ///     created then make payment. Previously was just making authorisation and then payment.
    ///     No conditional logic such that if not authorised then should't make payment.
    ///     At this point it is assumed that order was created with no validation errors, for e.g.
    ///     user authorised, no data issues etc.
    /// </summary>
    public class PaymentOrderHandler : IDomainHandler<OrderEvent>
    {
        /// <summary>
        ///     The _payment service
        /// </summary>
        private readonly IPaymentServiceMediator _paymentService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PaymentOrderHandler" /> class.
        /// </summary>
        /// <param name="paymentService">The payment service.</param>
        public PaymentOrderHandler(IPaymentServiceMediator paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        ///     Handles the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Handle(OrderEvent args)
        {
            using (_paymentService)
            {
                var dto = new PaymentDto
                {
                    Amount = args.Order.Amount,
                    Card = args.Order.Card,
                    Customer = args.Order.Customer
                };

                _paymentService.Bill(dto);
            }
        }
    }
}