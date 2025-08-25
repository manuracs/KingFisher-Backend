using KingFisher.Domain.Common.Enums;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Queries.List.Models;

public class EmployeeModel
{
	public string? FirstName { get; set; }

	public string? LastName { get; set; }

	public string? ProfileImageURL { get; set; }

	public DateTime DateOfBirth { get; set; } // we need to define date time extensions to manage the standard of the date time throughout the project

	public string? Email { get; set; }

	public WorkerPositionType PositionType { get; set; }
}
