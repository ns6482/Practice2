using System;

namespace TheTicketSellers.Infrastructure.Service
{
    /// <summary>
    ///     Service result
    /// </summary>
    public interface IResult
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        Guid? Id { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        Status Status { get; set; }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        object Data { get; set; }
    }
}