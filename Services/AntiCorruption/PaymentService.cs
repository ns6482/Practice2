using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using TheTicketSellers.Domain.OrderAggregate;
using TheTicketSellers.Services.Contracts;

namespace TheTicketSellers.Services.AntiCorruption
{
    [DebuggerStepThrough]
    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public class PaymentServiceClient : ClientBase<IPaymentService>, IPaymentService
    {
        //EndPointAddress should have interface and be injected, testability!!
        private readonly EndpointAddress _remoteAddress;
        //why isn't endpoint address in the config file?

        #region Public methods

        //replace signature with Order object
        public string Bill(Customer customer, decimal amount, CreditCard creditCard)
        {
            var result = Channel.Bill(customer, amount, creditCard);

            return result;
        }

        #endregion Public Methods

        #region Constructors

        public PaymentServiceClient()
        {
        }

        public PaymentServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public PaymentServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public PaymentServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
            _remoteAddress = remoteAddress;
        }

        public PaymentServiceClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        #endregion Constructors
    }
}