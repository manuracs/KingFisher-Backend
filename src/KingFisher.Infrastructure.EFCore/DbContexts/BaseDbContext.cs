using KingFisher.Domain.BaseModels.Contracts;
using KingFisher.Domain.Models.Employees;
using KingFisher.Domain.Models.FishFarms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KingFisher.Infrastructure.EFCore.DbContexts;

public class BaseDbContext(DbContextOptions options) : DbContext(options)
{

	#region DbSet
	public virtual DbSet<FishFarm> FishFarms { get; set; }

	public virtual DbSet<Employee> Employees { get; set; }

	public virtual DbSet<FishFarmEmployee> FishFarmEmployees { get; set; }
	#endregion


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		ArgumentNullException.ThrowIfNull(modelBuilder);

		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);

		// Following logic is to set the Kind as UTC of all the DateTime values fetched from the db. This assumes all the DateTime values
		// are stored as UTC format. If not they should be stored as UTC!
		var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
			v => v,
			v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

		foreach (var entityType in modelBuilder.Model.GetEntityTypes())
		{
			var idProperty = entityType.FindProperty("Id");
			// Only configured for Guid. Will have to do for other types as well
			if (idProperty != null && idProperty.ClrType == typeof(Guid))
			{
				idProperty.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
				idProperty.SetDefaultValueSql("NEWID()"); // For SQL Server
			}

			if (entityType.ClrType.IsAssignableTo(typeof(ITimeTrackedEntity)))
			{
				modelBuilder.Entity(entityType.ClrType).Property(nameof(ITimeTrackedEntity.Created)).HasDefaultValueSql("GETUTCDATE()");
				modelBuilder.Entity(entityType.ClrType).Property(nameof(ITimeTrackedEntity.Modified)).HasDefaultValueSql("GETUTCDATE()");
			}

			foreach (var property in entityType.GetProperties())
			{
				if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
				{
					property.SetValueConverter(dateTimeConverter);
				}
			}
		}
	}
}
