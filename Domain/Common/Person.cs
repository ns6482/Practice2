using System;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Domain.Common
{
    /// <summary>
    ///     Base class for people, typically a user, customer etc. will have an id and email address, could add more to DRY up
    ///     code
    /// </summary>
    public abstract class Person : Entity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected Person(Guid id) : base(id)
        {
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        protected new Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>
        ///     The email address.
        /// </value>
        protected EmailAddress EmailAddress { get; set; }
    }
}