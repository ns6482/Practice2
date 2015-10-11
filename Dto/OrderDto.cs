using System;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Dto
{
    /// <summary>
    ///     Used for persisting order to databse
    /// </summary>
    public class OrderDto : IDto
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        ///     The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }

        /// <summary>
        ///     Gets or sets the event identifier.
        /// </summary>
        /// <value>
        ///     The event identifier.
        /// </value>
        public Guid EventId { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public int Quantity { get; set; }
    }
}