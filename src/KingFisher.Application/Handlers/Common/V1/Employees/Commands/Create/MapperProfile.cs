using AutoMapper;
using KingFisher.Domain.Models.Employees;
using KingFisher.Domain.Models.ValueObjects;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Commands.Create;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Command, Employee>()
			.ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImageURL != null ? new Uri(src.ProfileImageURL) : null))
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => new PersonName(src.FirstName!, src.LastName!)));
	}
}
