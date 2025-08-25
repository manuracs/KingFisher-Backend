using KingFisher.Domain.BaseModels.Abstractions;
using KingFisher.Domain.Common.Enums;
using KingFisher.Domain.Models.ValueObjects;

namespace KingFisher.Domain.Models.Employees;

public class Employee : AggregateEntity<Guid>
{
	public PersonName Name { get; set; }

	public Uri? ProfileImage { get; set; }

	public DateTime DateOfBirth { get; set; } // we need to define date time extensions to manage the standard of the date time throughout the project

	public string Email { get; set; }

	public WorkerPositionType PositionType { get; set; }
}
