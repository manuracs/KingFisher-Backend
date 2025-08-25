namespace KingFisher.Domain.BaseModels.Contracts;

public interface ITimeTrackedEntity
{
	public DateTime Created { get; set; }

	public DateTime Modified { get; set; }
}
