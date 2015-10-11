using System;
using TheTicketSellers.Events;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Domain.OrderAggregate
{
    /// <summary>
    ///     Order aggregate for Order domain
    /// </summary>
    public class Order : DomainAggregate
    {
        //use pence rather than decimals for currency, find easier to work with, potentially less space in the db 
        //customer and credit card will have their own invariants upon creation
        //event should be part of the order
        //I like the idea of having an errors array in DomainAggregate

        /// <summary>
        ///     Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="card">The card.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="evt">The evt.</param>
        /// <param name="created">The created.</param>
        /// <param name="user">The user.</param>
        public Order(Guid id, Customer customer, CreditCard card, decimal amount, int quantity, Event evt,
            DateTime created, User user)
        {
            Customer = customer;
            Card = card;
            Amount = amount;
            Quantity = quantity;
            Evt = evt;
            Created = created;
            User = user;
            Id = id;
            CreateOrder();
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { private set; get; }

        /// <summary>
        ///     Gets or sets the customer.
        /// </summary>
        /// <value>
        ///     The customer.
        /// </value>
        public Customer Customer { private set; get; }

        /// <summary>
        ///     Gets the card.
        /// </summary>
        /// <value>
        ///     The card.
        /// </value>
        public CreditCard Card { get; private set; }

        /// <summary>
        ///     Gets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public decimal Amount { get; private set; }

        /// <summary>
        ///     Gets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public int Quantity { get; private set; }

        /// <summary>
        ///     Gets the evt.
        /// </summary>
        /// <value>
        ///     The evt.
        /// </value>
        public Event Evt { get; private set; }

        /// <summary>
        ///     Gets the created.
        /// </summary>
        /// <value>
        ///     The created.
        /// </value>
        public DateTime Created { get; private set; }

        /// <summary>
        ///     Gets the user.
        /// </summary>
        /// <value>
        ///     The user.
        /// </value>
        public User User { get; private set; }

        /// <summary>
        ///     Creates the order.
        /// </summary>
        private void CreateOrder()
        {
            if (!HasPermissions()) return;
            if (IsValid())
                //keeping with the single responsability design pattern, create a payment for valid order
                //let our handler deal with the actual event, that logic doesn't belong here
                DomainEvents.Raise(new OrderEvent {Order = this});
        }

        /// <summary>
        ///     Determines whether this instance has permissions.
        ///     might make sense to place this in the base class DomainAggregate than can be overridden
        /// </summary>
        /// <returns></returns>
        private bool HasPermissions()
        {
            if (User.Type == "readOnly")
            {
                Errors.Add("User does not have permissions");
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Determines whether this instance is valid.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Cannot create an order for zero tickets!</exception>
        private bool IsValid()
        {
            if (Customer == null || Card == null)
            {
                Errors.Add("Customer or card null");
            }

            //why is the validation for customer being done in OrderService, should be customer domain model
            if (Customer != null) //if email address is invalid error will be thrown
                //reg expression , what about . etc. Either wau Email address should be a seperate value type object with it's own validation built in
            {
                Errors.Add("Email address invalid");
            }

            if (Customer != null && Customer.CustomerAge < 16) // customers must be 16 yrs or older to place orders
            {
                Errors.Add("Customer less than 16");
            }

            if (Amount <= 0)
            {
                Errors.Add("amount less than 0");
            }

            if (Quantity <= 0)
            {
                throw new Exception("Cannot create an order for zero tickets!");
            }

            if (Evt.Price != (Amount/Quantity))
            {
                Errors.Add("Could be losing money yo!");
            }

            return !HasErrors();
        }
    }
}