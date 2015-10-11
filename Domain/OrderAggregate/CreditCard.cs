using System;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Domain.OrderAggregate
{
    /// <summary>
    ///     Credit card entitiy, here the Entity object this class inherits  is simple and assumes id are always a guid.
    ///     However the case here is that it could be more complex and consist of a combination of credit card and issue number
    ///     and name
    ///     So really an Identity object might be more useful
    /// </summary>
    public class CreditCard : Entity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreditCard" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="scheme">The scheme.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="cvv">The CVV.</param>
        /// <param name="nameOnCard">The name on card.</param>
        /// <param name="issueNumber">The issue number.</param>
        public CreditCard(Guid id, string scheme, string cardNumber, string startDate, string endDate, string cvv,
            string nameOnCard, string issueNumber) : base(id)
        {
            Scheme = scheme;
            CardNumber = cardNumber;
            StartDate = startDate;
            EndDate = endDate;
            Cvv = cvv;
            NameOnCard = nameOnCard;
            IssueNumber = issueNumber;

            //would expect lot of validation here
        }

        /// <summary>
        ///     Gets the scheme.
        /// </summary>
        /// <value>
        ///     The scheme.
        /// </value>
        public string Scheme { get; private set; }

        /// <summary>
        ///     Gets the card number.
        /// </summary>
        /// <value>
        ///     The card number.
        /// </value>
        public string CardNumber { get; private set; }

        /// <summary>
        ///     Gets the start date.
        /// </summary>
        /// <value>
        ///     The start date.
        /// </value>
        public string StartDate { get; private set; }

        /// <summary>
        ///     Gets the end date.
        /// </summary>
        /// <value>
        ///     The end date.
        /// </value>
        public string EndDate { get; private set; }

        /// <summary>
        ///     Gets the CVV.
        /// </summary>
        /// <value>
        ///     The CVV.
        /// </value>
        public string Cvv { get; private set; }

        /// <summary>
        ///     Gets the name on card.
        /// </summary>
        /// <value>
        ///     The name on card.
        /// </value>
        public string NameOnCard { get; private set; }

        /// <summary>
        ///     Gets the issue number.
        /// </summary>
        /// <value>
        ///     The issue number.
        /// </value>
        public string IssueNumber { get; private set; }
    }
}