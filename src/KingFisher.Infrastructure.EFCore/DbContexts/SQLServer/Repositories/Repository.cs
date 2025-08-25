using KingFisher.Application.Contracts;
using KingFisher.Domain.BaseModels.Contracts;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.Repositories;

public abstract class Repository : IRepository
{
	protected Repository(SQLServerDBContext context)
	{
		Context = context;
	}

	protected SQLServerDBContext Context { get; set; }
}

public abstract class Repository<TEntity> : Repository<TEntity, Guid>
	where TEntity : class, IAggregateRoot<Guid>, new()
{
	protected Repository(SQLServerDBContext context) : base(context)
	{
		Context = context;
	}
}

public abstract class Repository<TEntity, TKey> : Repository, IRepository<TEntity, TKey>
	where TEntity : class, IAggregateRoot<TKey>, new()
	where TKey : IEquatable<TKey>
{
	protected Repository(SQLServerDBContext context) : base(context)
	{
		Context = context;
	}

	public void Add(TEntity entity)
	{
		Context.Set<TEntity>().Add(entity);
	}

	public void AddRange(IEnumerable<TEntity> entities)
	{
		Context.Set<TEntity>().AddRange(entities);
	}

	public void Attach(TEntity entity)
	{
		Context.Attach(entity);
	}

	public void Update(TEntity entity)
	{
		Context.Update(entity);
	}

	public void AttachRange(IEnumerable<TEntity> entities)
	{
		Context.AttachRange(entities);
	}

	public void Remove(TEntity entity)
	{
		Context.Remove(entity);
	}

	public void RemoveRange(IEnumerable<TEntity> entities)
	{
		Context.RemoveRange(entities);
	}
}