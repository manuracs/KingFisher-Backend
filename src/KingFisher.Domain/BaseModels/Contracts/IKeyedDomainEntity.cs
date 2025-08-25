namespace KingFisher.Domain.BaseModels.Contracts;

public interface IKeyedDomainEntity<TKey> : IDomainEntity
	where TKey : IEquatable<TKey>
{
	public TKey Id { get; set; }
}
