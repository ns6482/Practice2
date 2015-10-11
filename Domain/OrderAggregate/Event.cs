using System;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Domain.OrderAggregate
{
    /// <summary>
    ///     Event domain, currencies use pence instead of deciml
    /// </summary>
    public class Event : Entity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Event" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="venue">The venue.</param>
        /// <param name="tickets">The tickets.</param>
        /// <param name="price">The price.</param>
        public Event(Guid id, string name, string venue, int tickets, decimal price) : base(id)
        {
            Name = name;
            Venue = venue;
            Tickets = tickets;
            Price = price;
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets the venue.
        /// </summary>
        /// <value>
        ///     The venue.
        /// </value>
        public string Venue { get; private set; }

        /// <summary>
        ///     Gets the tickets.
        /// </summary>
        /// <value>
        ///     The tickets.
        /// </value>
        public int Tickets { get; private set; }

        /// <summary>
        ///     Gets the price.
        /// </summary>
        /// <value>
        ///     The price.
        /// </value>
        public decimal Price { get; private set; }
    }
}