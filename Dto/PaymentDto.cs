using TheTicketSellers.Domain.OrderAggregate;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Dto
{
    /// <summary>
    ///     Typically used for persisting payment record to databse
    /// </summary>
    public class PaymentDto : IDto
    {
        /// <summary>
        ///     Gets or sets the customer.
        /// </summary>
        /// <value>
        ///     The customer.
        /// </value>
        public Customer Customer { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the card.
        /// </summary>
        /// <value>
        ///     The card.
        /// </value>
        public CreditCard Card { get; set; }
    }
}