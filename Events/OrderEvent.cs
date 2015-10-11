using TheTicketSellers.Domain.OrderAggregate;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Events
{
    /// <summary>
    ///     Order is raised
    /// </summary>
    public class OrderEvent : IDomainEvent
    {
        /// <summary>
        ///     Gets or sets the order.
        /// </summary>
        /// <value>
        ///     The order.
        /// </value>
        public Order Order { get; set; }
    }
}