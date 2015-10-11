using System;

namespace TheTicketSellers.Infrastructure.Domain
{
    /// <summary>
    ///     To be used by objects that are entities, i.e. can be uniqiuely identified and mutable
    ///     Could be more here, for e.g. might be more than just id to
    ///     identify
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        Guid Id { set; get; }
    }
}