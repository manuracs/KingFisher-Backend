using KingFisher.Application.Handlers.Common.Requests;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Register.Models;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Register;

public class Command : CommandRequest
{
	public string FarmName { get; set; }

	public GPSPositionModel GPSPosition { get; set; }

	public int CagesCount { get; set; }

	public bool HasBarge { get; set; }

	public string FarmImageURL { get; set; }
}
