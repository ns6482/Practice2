using System;
using TheTicketSellers.Domain.Common;

namespace TheTicketSellers.Domain.OrderAggregate
{
    /// <summary>
    ///     Customer domain model
    /// </summary>
    public class Customer : Person
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Customer" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        public Customer(Guid id, string firstName, string lastName, DateTime dateOfBirth) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        //EmailAddress should be a common ValueType class, with it's own invariants. Email addresses can be complex, with different invariants etc.

        /// <summary>
        ///     Gets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>
        ///     Gets or sets the date of birth.
        /// </summary>
        /// <value>
        ///     The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///     Gets the customer age.
        /// </summary>
        /// <value>
        ///     The customer age.
        /// </value>
        public int CustomerAge
        {
            get
            {
                var now = DateTime.Now;
                //again this calculation belongs in the customer model, doesn't belong in OrderService

                var customerAge = now.Year - DateOfBirth.Year;
                if (now.Month < DateOfBirth.Month ||
                    (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day))
                {
                    customerAge--;
                }

                return customerAge;
            }
        }
    }
}