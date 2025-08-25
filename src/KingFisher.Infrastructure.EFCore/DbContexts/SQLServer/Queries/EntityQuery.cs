using KingFisher.Application.BaseContracts;
using KingFisher.Domain.BaseModels.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.Queries;

public abstract class EntityQuery : IEntityQuery
{
	protected EntityQuery(SQLServerDBContext context)
	{
		Context = context;
	}

	protected SQLServerDBContext Context { get; set; }
}

public abstract class EntityQuery<TEntity> : EntityQuery<TEntity, Guid>
	where TEntity : class, IKeyedDomainEntity<Guid>, new()
{
	protected EntityQuery(SQLServerDBContext context) : base(context)
	{
		Context = context;
	}
}

public abstract class EntityQuery<TEntity, TKey> : EntityQuery, IEntityQuery<TEntity, TKey>
	where TEntity : class, IKeyedDomainEntity<TKey>, new()
	where TKey : IEquatable<TKey>
{
	protected EntityQuery(SQLServerDBContext context) : base(context)
	{
		Context = context;
	}

	public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await Context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);
	}

	public async Task<IList<TEntity>> GetEntitiesByIdsAsync(IEnumerable<TKey> ids, Expression<Func<TEntity, TEntity>>? selector = default, CancellationToken cancellationToken = default)
	{
		var result = await Context.Set<TEntity>().AsNoTracking().WhereIn(i => i.Id, ids).ToListAsync(cancellationToken).ConfigureAwait(false);

		return result;
	}

	public async Task<IList<TOutModel>> GetEntitiesByIdsAsync<TOutModel>(IEnumerable<TKey> ids, Expression<Func<TEntity, TOutModel>> selector, CancellationToken cancellationToken = default)
	{
		return await Context.Set<TEntity>().AsNoTracking().WhereIn(i => i.Id, ids).Select(selector).ToListAsync(cancellationToken).ConfigureAwait(false);
	}

	public async Task<TEntity> GetEntityByIdAsync(TKey id, Expression<Func<TEntity, TEntity>>? selector = default, CancellationToken cancellationToken = default)
	{
		var result = await Context.Set<TEntity>().AsNoTracking().Where(i => i.Id.Equals(id)).UseSelector(selector!).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

		return result!;
	}

	public async Task<TOutModel> GetEntityByIdAsync<TOutModel>(TKey id, Expression<Func<TEntity, TOutModel>> selector, CancellationToken cancellationToken = default)
	{
		var result = await Context.Set<TEntity>().AsNoTracking().Where(i => i.Id.Equals(id)).Select(selector).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

		return result!;
	}

	public async Task<bool> IsValidEntityIdAsync(TKey id, CancellationToken cancellationToken = default)
	{
		var result = await Context.Set<TEntity>().AsNoTracking().Where(i => i.Id.Equals(id)).AnyAsync(cancellationToken).ConfigureAwait(false);

		return result;
	}
}