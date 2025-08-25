using KingFisher.Application.Contracts;
using KingFisher.Infrastructure.EFCore.DbContexts.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KingFisher.ServiceRegistrations;

public static class DBContextInstaller
{
	public static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContextPool<SQLServerDBContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
				sqlServerOptionsAction: sqlOptions =>
				{
					sqlOptions.MigrationsAssembly(typeof(SQLServerDBContext).GetTypeInfo().Assembly.GetName().Name);
				}
			);
#if DEBUG
			options.EnableSensitiveDataLogging();
#endif
		});
		services.AddScoped<IUnitOfWork, SQLServerUnitOfWork>();
	}
}
