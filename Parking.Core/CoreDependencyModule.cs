using Autofac;
using Parking.Abstractions.Services;
using Parking.Core.Services;

namespace Parking.Core
{
    public class CoreDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RatesService>().As<IRatesService>().InstancePerDependency();
            builder.RegisterType<PaymentService>().As<IPaymentService>().InstancePerDependency();
            builder.RegisterType<PlacesService>().As<IPlacesService>().InstancePerDependency();
            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerDependency();
            builder.RegisterType<VehicleService>().As<IVehicleService>().InstancePerDependency();
        }
    }
}
