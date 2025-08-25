namespace KingFisher.Domain.BaseModels.Contracts;

public interface IDomainEntity
{
	public virtual void OnBeforeInsert() { }

	public virtual void OnBeforeUpdate() { }

	public virtual void OnBeforeDelete() { }
}
