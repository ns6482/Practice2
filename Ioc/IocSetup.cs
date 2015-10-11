using System.Reflection;
using Ninject;
using TheTicketSellers.Services.AntiCorruption;
using TheTicketSellers.Services.Contracts;
using TheTicketSellers.Services.Implementation;

namespace TheTicketSellers.Ioc
{
    internal class IocSetup
    {
        public IocSetup()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Load(Assembly.GetExecutingAssembly());

                //should get this from config file
                var endpointAddress = "someEndpointFromConfig";

                kernel.Bind<IPaymentService>()
                    .To<PaymentServiceClient>()
                    .WithConstructorArgument(endpointAddress);

                kernel.Bind<IPaymentServiceMediator>()
                    .To<PaymentServiceMediator>();
            }
        }
    }
}