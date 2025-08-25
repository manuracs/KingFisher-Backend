using AutoMapper;
using KingFisher.Domain.Models.FishFarms;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.WorkerAssign;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Command, FishFarmEmployee>();
	}
}
