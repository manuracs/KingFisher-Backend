using KingFisher.Application.Handlers.Common.Requests;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Queries.Details;

public class Query : QueryRequest
{
	public Query()
	{
	}

	public Query(Guid employeeId)
	{
		EmployeeId = employeeId;
	}

	internal Guid EmployeeId { get; private set; }

	public void AssignEmployeeId(Guid Id)
	{
		EmployeeId = Id;
	}
}
