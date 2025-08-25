using KingFisher.Application.Handlers.Common.Requests;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.WorkerAssign;

public class Command : CommandRequest
{
	public Guid EmployeeId { get; set; }

	public Guid FishFarmId { get; set; }

	public DateTime? CertificationExpiryDate { get; set; }
}
