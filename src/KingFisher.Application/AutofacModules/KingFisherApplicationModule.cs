using Autofac;

namespace KingFisher.Application.AutofacModules;

public class KingFisherApplicationModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterAssemblyTypes(typeof(KingFisherApplicationModule).Assembly)
			.AsImplementedInterfaces()
			.InstancePerLifetimeScope();
	}
}
