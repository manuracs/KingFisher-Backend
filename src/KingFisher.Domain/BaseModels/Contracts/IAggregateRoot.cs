namespace KingFisher.Domain.BaseModels.Contracts;

public interface IAggregateRoot<TKey> : IKeyedDomainEntity<TKey>
	where TKey : IEquatable<TKey>
{
}

