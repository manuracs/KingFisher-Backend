using KingFisher.Infrastructure.EFCore.DbContexts.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace KingFisher.Api.Extensions;

public static class MigrationExtensions
{
	public static async Task MigrateSQLServerDbContextAsync(this IHost host, IHostEnvironment hostEnvironment)
	{
		await using var scope = host.Services.CreateAsyncScope();
		var services = scope.ServiceProvider;

		var logger = services.GetRequiredService<ILogger<SQLServerDBContext>>();
		var sqlServerDBContext = services.GetRequiredService<SQLServerDBContext>();


		try
		{
			var timeout = TimeSpan.FromMinutes(5);
			var defaultCommandTimeout = sqlServerDBContext.Database.GetCommandTimeout();
			sqlServerDBContext.Database.SetCommandTimeout(timeout);

			var cts = new CancellationTokenSource(timeout);

			using (cts)
			{
				await sqlServerDBContext.MigrateDbAsync(cts.Token);
			}

			sqlServerDBContext.Database.SetCommandTimeout(defaultCommandTimeout);
		}
		catch (Exception exception)
		{
			logger.LogError(exception, "An error occurred while migrating the database");
			throw;
		}
	}
}
