namespace TheTicketSellers.Infrastructure.Domain
{
    /// <summary>
    ///     totally shameful copy here from Udi Dahan, google "Domain Event Salvation"
    ///     not to be comapred to nservicebus like events, these are synchronous in nature
    ///     the intention is to help deal with side effects, and remove logic that doesn't
    ///     belong in the domain layer. Powerful concept and keeps the code a lot cleaner,
    ///     focused and easier to test.
    ///     You could go further and make this easier to work with ORM tools like EF,
    ///     see https://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/
    /// </summary>
    public interface IDomainEvent
    {
    }
}