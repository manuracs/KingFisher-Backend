using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.Employees.Queries.Details.Models;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Queries.Details;

public class Response : DetailResponse<EmployeeModel>
{
	public Response(EmployeeModel item) : base(item)
	{
	}
}
