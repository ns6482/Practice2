using TheTicketSellers.Database;
using TheTicketSellers.Dto;
using TheTicketSellers.Events;
using TheTicketSellers.Infrastructure.Domain;

namespace TheTicketSellers.Services.EventHandlers
{
    public class DataOrderHandler : IDomainHandler<OrderEvent>
    {
        public void Handle(OrderEvent args)
        {
            //prob should be passing in id 
            var dto = new OrderDto
            {
                Id = args.Order.Id,
                CustomerId = args.Order.Customer.Id,
                EventId = args.Order.Evt.Id,
                Quantity = args.Order.Quantity
            };
            OrderDataAccess.Create(dto);
        }
    }
}