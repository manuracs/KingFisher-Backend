using KingFisher.Domain.BaseModels.Abstractions;
using KingFisher.Domain.Models.ValueObjects;

namespace KingFisher.Domain.Models.FishFarms;

public class FishFarm : AggregateTimeTrackedEntity<Guid>
{
	private readonly List<FishFarmEmployee> _fishFarmEmployees = [];

	public string FarmName { get; set; }

	public GPSPosition GPSPosition { get; set; }

	public int CagesCount { get; set; }

	public bool HasBarge { get; set; }

	public Uri FarmImageURL { get; set; }

	public virtual IReadOnlyCollection<FishFarmEmployee> FishFarmEmployees => _fishFarmEmployees;

	public void Add(FishFarmEmployee employee)
	{
		_fishFarmEmployees.Add(employee);
	}
}
