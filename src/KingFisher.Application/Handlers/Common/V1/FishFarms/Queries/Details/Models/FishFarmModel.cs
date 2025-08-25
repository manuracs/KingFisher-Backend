namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.Details.Models;

public class FishFarmModel
{
	public Guid Id { get; set; }

	public string FarmName { get; set; }

	public GPSPositionModel GPSPosition { get; set; }

	public int CagesCount { get; set; }

	public bool HasBarge { get; set; }

	public string FarmImageURL { get; set; }
}
