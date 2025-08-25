using Asp.Versioning;
using KingFisher.Application.Handlers.Common.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Base = KingFisher.Application.Handlers.Common.V1.FishFarms;

namespace KingFisher.Presentation.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
public class FishFarmsController : BaseApiController
{
	[HttpGet()]
	[ProducesResponseType<Base.Queries.List.Response>(StatusCodes.Status200OK)]
	public Task<BaseResponse> GetAllFishFarmsList([FromQuery] Base.Queries.List.Query query)
	{
		return Send(query);
	}


	[HttpGet("{id:guid}")]
	[ProducesResponseType<Base.Queries.Details.Response>(StatusCodes.Status200OK)]
	public Task<BaseResponse> GetFishFarmById([FromRoute] Guid id, [FromQuery] Base.Queries.Details.Query query)
	{
		ArgumentNullException.ThrowIfNull(query);

		query.AssignFarmId(id);

		return Send(query);
	}

	[HttpPost]
	[ProducesResponseType<CreatedResponse<Guid>>(StatusCodes.Status200OK)]
	public Task<BaseResponse> CreateFishFarm([FromBody] Base.Commands.Register.Command command)
	{
		ArgumentNullException.ThrowIfNull(command);
		return Send(command);
	}

	[HttpPost("Worker")]
	[ProducesResponseType<SuccessResponse>(StatusCodes.Status200OK)]
	public Task<BaseResponse> AssignEmployee([FromBody] Base.Commands.WorkerAssign.Command command)
	{
		ArgumentNullException.ThrowIfNull(command);
		return Send(command);
	}
}
