using KingFisher.Domain.BaseModels.Contracts;

namespace KingFisher.Domain.BaseModels.Abstractions;


public abstract class BaseDomainEntity<TKey> : IKeyedDomainEntity<TKey>
	where TKey : IEquatable<TKey>
{
	public TKey Id { get; set; }
}

