using KingFisher.Domain.BaseModels.Abstractions;
using KingFisher.Domain.Models.Employees;

namespace KingFisher.Domain.Models.FishFarms;

public class FishFarmEmployee : BaseDomainEntity<Guid>
{
	public Guid FishFarmId { get; set; }

	public FishFarm FishFarm { get; set; }

	public Guid EmployeeId { get; set; }

	public Employee Employee { get; set; }

	public DateTime CertificationExpiryDate { get; set; }
}
