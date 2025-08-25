using KingFisher.Domain.BaseModels.Contracts;

namespace KingFisher.Domain.BaseModels.Abstractions;

public abstract class AggregateEntity<TKey> : IAggregateRoot<TKey>
	where TKey : IEquatable<TKey>
{
	public TKey Id { get; set; }
}
