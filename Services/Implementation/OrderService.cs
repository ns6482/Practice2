using System;
using System.IO;
using System.Threading;
using TheTicketSellers.Domain.OrderAggregate;
using TheTicketSellers.Infrastructure.Service;
using TheTicketSellers.Services.Contracts;

namespace TheTicketSellers.Services.Implementation
{
    // not sure why OrderService is static, statics are harder to test becuase of the procedural nature, impossible to mock 

    //Single resposability issue, why is get event in order service? I wouldn't expect to find it in an "order service"

    //I don't like the permissions logic within the create method, at least an attribute would be better, in that it is reusable and less intrusive
    //also having this in the create action makes it harder to test, depdendancy on user

    //there should be an order model in the domain layer, all the invariants, i.e. validation should belong there not in the service
    //I think take payment should be a seperate method

    //wouldn't you typically take payment once the order has been made, 

    //the payment should be a side effect of creating the order, therefore should really create an order, then raise a payment event that gets handled
    //not to be confused with async events, like nservicebus, these are sync events that help us keep the domain logic clean, and deal with the side effects seperatley

    //surely you would want to bill only if you can authorise the payment, why is it just calling authorise and then bill

    //OrderDataAccess should be injected, again would discourage use of static for testing purposes

    //OrderDataAccess pass in DTO
    /// <summary>
    /// </summary>
    public class OrderService : IOrderService
    {
        //for simplicity keep it bool, but an enum with different status codes would be more useful

        //also would probably want to return the order
        /// <summary>
        ///     Creates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="evt">The evt.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="creditCard">The credit card.</param>
        /// <returns></returns>
        public OrderResult Create(Customer customer, Event evt, int amount, int quantity, CreditCard creditCard)
        {
            var result = new OrderResult();
            try
            {
                //as above, don't believe permission logic  belongs here

                var user = (User) Thread.CurrentPrincipal.Identity;
                var order = new Order(Guid.NewGuid(), customer, creditCard, amount, quantity, evt, DateTime.Now, user);

                //validation on order failed
                if (order.HasErrors())
                {
                    result.Status = Status.Fail;
                    result.Data = order.Errors;
                    return result;
                }

                //order successful
                result.Id = order.Id;
                result.Status = Status.Ok;
                return result;
            }
                //not sure if this should really occur at a lover level
            catch (Exception ex)
            {
                File.AppendAllText(@"C:\Errors.txt", ex.Message);
                result.Status = Status.Fail;
                return result;
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}