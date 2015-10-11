using System;
using TheTicketSellers.Domain.OrderAggregate;
using TheTicketSellers.Infrastructure.Service;

namespace TheTicketSellers.Services.Contracts
{
    /// <summary>
    ///     Order service, creates an order
    /// </summary>
    public interface IOrderService : IDisposable
    {
        /// <summary>
        ///     Creates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="evt">The evt.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="creditCard">The credit card.</param>
        /// <returns></returns>
        OrderResult Create(Customer customer, Event evt, int amount, int quantity, CreditCard creditCard);
    }
}