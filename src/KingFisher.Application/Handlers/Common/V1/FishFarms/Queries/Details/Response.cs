using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.Details.Models;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.Details;

public class Response : DetailResponse<FishFarmModel>
{
	public Response(FishFarmModel item) : base(item)
	{
	}
}
