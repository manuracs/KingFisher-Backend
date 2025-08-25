using KingFisher.Domain.BaseModels.Contracts;
using System.Linq.Expressions;

namespace KingFisher.Application.BaseContracts;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Just a marker interface")]
public interface IEntityQuery { }

public interface IEntityQuery<TEntity> : IEntityQuery<TEntity, Guid>
	where TEntity : class, IKeyedDomainEntity<Guid>, new()
{

}

public interface IEntityQuery<TEntity, in TKey>
	where TEntity : class, IKeyedDomainEntity<TKey>, new()
	where TKey : IEquatable<TKey>
{
	Task<TEntity> GetEntityByIdAsync(TKey id, Expression<Func<TEntity, TEntity>>? selector = default, CancellationToken cancellationToken = default);

	Task<TOutModel> GetEntityByIdAsync<TOutModel>(TKey id, Expression<Func<TEntity, TOutModel>> selector, CancellationToken cancellationToken = default);

	Task<IList<TEntity>> GetEntitiesByIdsAsync(IEnumerable<TKey> ids, Expression<Func<TEntity, TEntity>>? selector = default, CancellationToken cancellationToken = default);

	Task<IList<TOutModel>> GetEntitiesByIdsAsync<TOutModel>(IEnumerable<TKey> ids, Expression<Func<TEntity, TOutModel>> selector, CancellationToken cancellationToken = default);

	Task<bool> IsValidEntityIdAsync(TKey id, CancellationToken cancellationToken = default);

	Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}
