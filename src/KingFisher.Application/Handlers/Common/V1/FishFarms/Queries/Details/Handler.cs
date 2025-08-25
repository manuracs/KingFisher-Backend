using AutoMapper;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.Details.Models;
using KingFisher.Application.Queries.FishFarms;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.Details;

public class Handler : BaseRequestHandler<Query>
{
	private readonly IFishFarmQuery _farmQuery;
	private readonly IMapper _mapper;

	public Handler(IFishFarmQuery farmQuery, IMapper mapper)
	{
		_farmQuery = farmQuery;
		_mapper = mapper;
	}

	public override async Task<BaseResponse> HandleAsync(Query request, CancellationToken cancellationToken)
	{
		var fishFarm = await _farmQuery.GetEntityByIdAsync(request.FishFarmId, cancellationToken: cancellationToken).ConfigureAwait(false);

		if (fishFarm is null)
		{
			return new ErrorResponse("Fish farm not found.");
		}

		var item = _mapper.Map<FishFarmModel>(fishFarm);

		return new Response(item);
	}
}
