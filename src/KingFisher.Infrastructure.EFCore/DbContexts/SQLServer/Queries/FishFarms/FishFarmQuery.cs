using KingFisher.Application.Queries.FishFarms;
using KingFisher.Domain.Models.FishFarms;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.Queries.FishFarms;

public class FishFarmQuery : EntityQuery<FishFarm>, IFishFarmQuery
{
	public FishFarmQuery(SQLServerDBContext context) : base(context)
	{
	}
}
