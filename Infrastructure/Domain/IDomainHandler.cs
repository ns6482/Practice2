namespace TheTicketSellers.Infrastructure.Domain
{
    /// <summary>
    ///     Handle events raised by DomainEvents
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDomainHandler<T> where T : IDomainEvent
    {
        /// <summary>
        ///     Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        void Handle(T @event);
    }
}