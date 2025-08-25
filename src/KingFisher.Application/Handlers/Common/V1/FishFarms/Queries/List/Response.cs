using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.List.Models;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.List;

public class Response : ListResponse<FishFarmModel>
{
	public Response(IEnumerable<FishFarmModel> items) : base(items)
	{
	}
}
