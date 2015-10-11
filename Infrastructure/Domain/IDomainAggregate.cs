using System.Collections.Generic;

namespace TheTicketSellers.Infrastructure.Domain
{
    /// <summary>
    ///     Domain aggregate, could typically have a HasPermission class
    ///     Guess could raise exceptions when error occurs
    /// </summary>
    public interface IDomainAggregate
    {
        /// <summary>
        ///     Gets or sets the errors.
        /// </summary>
        /// <value>
        ///     The errors.
        /// </value>
        List<string> Errors { get; set; }

        /// <summary>
        ///     Determines whether this instance has errors.
        /// </summary>
        /// <returns></returns>
        bool HasErrors();
    }
}