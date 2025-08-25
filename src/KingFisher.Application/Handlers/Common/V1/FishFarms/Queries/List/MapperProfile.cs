using AutoMapper;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.List.Models;
using KingFisher.Domain.Models.FishFarms;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Queries.List;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<FishFarm, FishFarmModel>()
		.ForMember(dest => dest.FarmImageURL, opt => opt.MapFrom(src => src.FarmImageURL.AbsoluteUri.ToString()))
		.ForMember(dest => dest.GPSPosition, opt => opt.MapFrom(src => new GPSPositionModel
		{
			Latitude = src.GPSPosition.Latitude,
			Longitude = src.GPSPosition.Longitude
		}));
	}
}
