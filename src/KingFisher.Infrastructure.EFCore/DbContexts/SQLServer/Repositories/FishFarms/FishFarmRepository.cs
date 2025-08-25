using KingFisher.Application.Repositories.FishFarms;
using KingFisher.Domain.Models.FishFarms;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.Repositories.FishFarms;

public class FishFarmRepository : Repository<FishFarm>, IFishFarmRepository
{
	public FishFarmRepository(SQLServerDBContext context) : base(context)
	{
	}
}
