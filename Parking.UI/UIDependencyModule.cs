using Autofac;

namespace Parking.UI
{
    public class UIDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Main>();
            builder.RegisterType<Payments>();
            builder.RegisterType<Persons>();
            builder.RegisterType<Places>();
            builder.RegisterType<Rates>();
            builder.RegisterType<AddPlaceForm>();
            builder.RegisterType<Vehicles>();
            builder.RegisterType<AddDatesForm>();
        }
    }
}
