using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using TheTicketSellers.Domain.OrderAggregate;

namespace TheTicketSellers.Services.Contracts
{
    //appears to be legacy code and shoudl proabbly be a mediator/abstraction above, i.e. mediator class
    //this would make it relatively easy to replace, test, mock
    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    [ServiceContract(ConfigurationName = "App.ICreditCheckingService")]
    public interface IPaymentService : IDisposable
    {
        [OperationContract(Action = "http://tempuri.org/IPaymentService/Bill",
            ReplyAction = "http://tempuri.org/IPaymentService/Bill")]
        string Bill(Customer customer, decimal amount, CreditCard creditCard);
    }
}