using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.Employees.Queries.List.Models;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Queries.List;

public class Response : ListResponse<EmployeeModel>
{
	public Response(IEnumerable<EmployeeModel> items) : base(items)
	{
	}
}
