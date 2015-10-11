using System.Collections.Generic;

namespace TheTicketSellers.Infrastructure.Domain
{
    /// <summary>
    ///     Domain aggregate, could typically have a HasPermission class
    ///     Guess could raise exceptions when error occurs
    /// </summary>
    public abstract class DomainAggregate : IDomainAggregate
    {
        protected DomainAggregate()
        {
            Errors = new List<string>();
        }

        /// <summary>
        ///     Gets or sets the errors.
        /// </summary>
        /// <value>
        ///     The errors.
        /// </value>
        public List<string> Errors { get; set; }

        /// <summary>
        ///     Determines whether this instance has errors.
        /// </summary>
        /// <returns></returns>
        public bool HasErrors()
        {
            return Errors.Count > 0;
        }
    }
}