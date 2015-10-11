using System;

namespace TheTicketSellers.Infrastructure.Domain
{
    /// <summary>
    ///     To be used by objects that are entities, i.e. can be uniqiuely identified and mutable
    ///     Could be more here, for e.g. might be more than just id to
    ///     identify
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected Entity(Guid id)
        {
            Id = id;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; private set; }
    }
}