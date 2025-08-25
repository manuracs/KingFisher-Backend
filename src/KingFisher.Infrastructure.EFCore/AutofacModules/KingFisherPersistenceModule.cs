using Autofac;
using KingFisher.Infrastructure.EFCore.DbContexts;
using KingFisher.Infrastructure.EFCore.DbContexts.SQLServer;

namespace KingFisher.Infrastructure.EFCore.AutofacModules;

public class KingFisherPersistenceModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterAssemblyTypes(typeof(KingFisherPersistenceModule).Assembly)
			.Where(i => i.Namespace is not null)
			.Except<BaseDbContext>()
			.Except<SQLServerDBContext>()
			.AsImplementedInterfaces()
			.InstancePerLifetimeScope();
	}
}
