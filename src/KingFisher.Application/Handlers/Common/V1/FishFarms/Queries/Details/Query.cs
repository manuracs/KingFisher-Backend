using KingFisher.Application.Handlers.Common.Requests;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.Details;

public class Query : QueryRequest
{
	public Query()
	{
	}

	public Query(Guid fishFarmId)
	{
		FishFarmId = fishFarmId;
	}

	internal Guid FishFarmId { get; private set; }

	public void AssignFarmId(Guid id)
	{
		FishFarmId = id;
	}
}
