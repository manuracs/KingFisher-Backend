using KingFisher.Domain.BaseModels.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer;

public class SQLServerDBContext(DbContextOptions<SQLServerDBContext> options) : BaseDbContext(options)
{
	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		var changedEntities = ChangeTracker.Entries();

		foreach (var changedEntity in changedEntities)
		{
			if (changedEntity != null && changedEntity.Entity is IDomainEntity)
			{
				var entity = changedEntity.Entity as IDomainEntity;

				switch (changedEntity.State)
				{
					case EntityState.Added:
						OnBeforeAdd(entity!);
						break;
					case EntityState.Modified:
						OnBeforeUpdate(entity!);
						break;
					case EntityState.Deleted:
						OnBeforeDelete(entity!);
						break;
				}

			}
		}

		UpdateTimestamps();

		return base.SaveChangesAsync(cancellationToken);
	}
	public async Task MigrateDbAsync(CancellationToken cancellationToken = default)
	{
		await Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
	}

	private static void OnBeforeAdd(IDomainEntity entity) => entity.OnBeforeInsert();

	private static void OnBeforeUpdate(IDomainEntity entity) => entity.OnBeforeUpdate();

	private static void OnBeforeDelete(IDomainEntity entity) => entity.OnBeforeDelete();

	private void UpdateTimestamps()
	{
		var timestamp = DateTime.UtcNow;
		foreach (var entry in ChangeTracker.Entries().Where(i => i.Entity is ITimeTrackedEntity))
		{
			if (entry.State == EntityState.Added)
			{
				((ITimeTrackedEntity)entry.Entity).Created = timestamp;
			}

			((ITimeTrackedEntity)entry.Entity).Modified = timestamp;
		}
	}
}
