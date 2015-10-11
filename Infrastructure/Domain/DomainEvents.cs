using System;
using System.Collections.Generic;

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
    public static class DomainEvents
    {
        /// <summary>
        ///     The _actions
        /// </summary>
        [ThreadStatic] // each thread has its own callbacks
        private static List<Delegate> _actions;

        /// <summary>
        ///     Registers the specified callback.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callback">The callback.</param>
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            _actions = _actions ?? new List<Delegate>();
            _actions.Add(callback);
        }

        /// <summary>
        ///     Clears the callbacks.
        /// </summary>
        public static void ClearCallbacks()
        {
            _actions = null;
        }


        /// <summary>
        ///     Raises the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (_actions != null)
            {
                foreach (var action in _actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>) action)(args);
                    }
                }
            }
        }
    }
}