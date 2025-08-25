using Asp.Versioning;
using KingFisher.Application.Handlers.Common.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Base = KingFisher.Application.Handlers.Common.V1.Employees;

namespace KingFisher.Presentation.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
public class EmployeesController : BaseApiController
{

	[HttpGet()]
	[ProducesResponseType<Base.Queries.List.Response>(StatusCodes.Status200OK)]
	public Task<BaseResponse> GetAllEmployeesList([FromQuery] Base.Queries.List.Query query)
	{
		return Send(query);
	}


	[HttpGet("{id:guid}")]
	[ProducesResponseType<Base.Queries.Details.Response>(StatusCodes.Status200OK)]
	public Task<BaseResponse> GetEmployeeById([FromRoute] Guid id, [FromQuery] Base.Queries.Details.Query query)
	{
		ArgumentNullException.ThrowIfNull(query);

		query.AssignEmployeeId(id);

		return Send(query);
	}

	[HttpPost]
	[ProducesResponseType<CreatedResponse<Guid>>(StatusCodes.Status200OK)]
	public Task<BaseResponse> CreateEmployee([FromBody] Base.Commands.Create.Command command)
	{
		ArgumentNullException.ThrowIfNull(command);
		return Send(command);
	}
}
