using AutoMapper;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.List.Models;
using KingFisher.Application.Queries.FishFarms;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.List;

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
		var fishFarms = await _farmQuery.GetAllAsync(cancellationToken).ConfigureAwait(false);

		var items = _mapper.Map<List<FishFarmModel>>(fishFarms);

		return new Response(items);
	}
}
