using KingFisher.Domain.BaseModels.Contracts;

namespace KingFisher.Application.Contracts;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Just a marker interface")]
public interface IRepository { };

public interface IRepository<TEntity> : IRepository<TEntity, Guid>
	where TEntity : class, IAggregateRoot<Guid>, new()
{
}

public interface IRepository<TEntity, TKey>
	where TEntity : class, IAggregateRoot<TKey>, new()
	where TKey : IEquatable<TKey>
{
	void Add(TEntity entity);

	void AddRange(IEnumerable<TEntity> entities);

	void Attach(TEntity entity);

	void AttachRange(IEnumerable<TEntity> entities);

	void Remove(TEntity entity);

	void RemoveRange(IEnumerable<TEntity> entities);

	void Update(TEntity entity);
}