using Autofac;
using Autofac.Extensions.DependencyInjection;
using KingFisher.Application.AutofacModules;
using KingFisher.Infrastructure.EFCore.AutofacModules;

namespace KingFisher.Api.Extensions;

public static class ApiApplicationBuilderExtensions
{
	public static WebApplicationBuilder CreateWebApplicationBuilder(string[] args)
	{
		var builder = WebApplication.CreateBuilder(new WebApplicationOptions
		{
			Args = args,
			ContentRootPath = Directory.GetCurrentDirectory()
		});

		builder.Host
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureContainer<ContainerBuilder>(containerBuilder =>
			{
				containerBuilder.RegisterModule<KingFisherApplicationModule>();
				containerBuilder.RegisterModule<KingFisherPersistenceModule>();
			});

		return builder;
	}
}
