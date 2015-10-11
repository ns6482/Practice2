using System;

namespace TheTicketSellers.Infrastructure.Service
{
    /// <summary>
    ///     Used to return status codes when making service calls
    /// </summary>
    public abstract class ServiceResult : IResult
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        public Status Status { get; set; }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public object Data { get; set; }
    }
}