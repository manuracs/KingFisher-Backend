using AutoMapper;
using KingFisher.Domain.Models.FishFarms;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Register;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Command, FishFarm>()
			.ForMember(dest => dest.FarmImageURL, opt => opt.MapFrom(src => new Uri(src.FarmImageURL)))
			.ForMember(dest => dest.GPSPosition, opt => opt.MapFrom(src => new Domain.Models.ValueObjects.GPSPosition(src.GPSPosition.Latitude, src.GPSPosition.Longitude)));
	}
}
