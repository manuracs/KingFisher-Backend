using KingFisher.Domain.BaseModels.Contracts;

namespace KingFisher.Domain.BaseModels.Abstractions;

public abstract class BaseDomainTimeTrackedEntity<TKey> : IKeyedDomainEntity<TKey>, ITimeTrackedEntity
	where TKey : IEquatable<TKey>
{
	public TKey Id { get; set; }

	public DateTime Modified { get; set; }

	public DateTime Created { get; set; }
}

