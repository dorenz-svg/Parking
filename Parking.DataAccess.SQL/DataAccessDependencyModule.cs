using Autofac;
using Parking.Abstractions.Repositories;
using Parking.DataAccess.SQL.Repositories;

namespace Parking.DataAccess.SQL
{
    public class DataAccessDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => { return new ParkingContext(); })
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PersonRepository>().As<IPersonRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PlacesRepository>().As<IPlacesRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RatesRepository>().As<IRatesRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
