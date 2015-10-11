using System.Configuration;
using System.Data.SqlClient;
using TheTicketSellers.Dto;

namespace TheTicketSellers.Database
{
    /// <summary>
    ///     Use to persist order to database
    /// </summary>
    internal static class OrderDataAccess
    {
        /// <summary>
        ///     Creates the specified order dto.
        /// </summary>
        /// <param name="orderDto">The order dto.</param>
        public static void Create(OrderDto orderDto)
        {
            //NS should there really be an exception here if zero tickets
            //exceptions should be that , exeptions not for validation

            // Get the connection string from config, shouldn't be hard coded
            var connectionString = ConfigurationManager.AppSettings["dbConnectionStr"];

            // Generate the sql, use parameters to avoid SQL injection attacks
            var sql = @" dbo.Orders (Id, CustomerId, EventId, Quantity) VALUES(@id, @customerId, @eventId, @qty)";

            // Create a Sql Connection
            var connection = new SqlConnection(connectionString);

            // Open the connection and execute the sql
            connection.Open();

            // Create the Command object
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", orderDto.Id);
            command.Parameters.AddWithValue("@customerId", orderDto.CustomerId);
            command.Parameters.AddWithValue("@eventId", orderDto.EventId);
            command.Parameters.AddWithValue("@qty", orderDto.Quantity);

            command.ExecuteNonQuery();
            command.Dispose();

            //close connection and clear resources
            connection.Close();
            connection.Dispose();
        }
    }
}