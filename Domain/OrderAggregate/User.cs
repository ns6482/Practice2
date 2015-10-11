using System;
using System.Security.Principal;
using TheTicketSellers.Domain.Common;

namespace TheTicketSellers.Domain.OrderAggregate
{
    /// <summary>
    /// </summary>
    public class User : Person, IIdentity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="emailAddress">The email address.</param>
        public User(Guid id, string type, string name, EmailAddress emailAddress) : base(id)
        {
            EmailAddress = emailAddress;
            Type = type;
            Name = name;
        }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public string Type { get; private set; }

        /// <summary>
        ///     Gets or sets the type of authentication used.
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        ///     Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        public bool IsAuthenticated { set; get; }

        /// <summary>
        ///     Gets the name of the current user.
        /// </summary>
        public string Name { get; private set; }
    }
}