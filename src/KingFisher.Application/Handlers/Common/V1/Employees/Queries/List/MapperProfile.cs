using AutoMapper;
using KingFisher.Application.Handlers.Common.V1.Employees.Queries.List.Models;
using KingFisher.Domain.Models.Employees;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Queries.List;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Employee, EmployeeModel>()
		.ForMember(dest => dest.ProfileImageURL, opt => opt.MapFrom(src => src.ProfileImage != null ? src.ProfileImage.AbsoluteUri.ToString() : string.Empty))
		.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name.FirstName))
		.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Name.LastName));
	}
}
