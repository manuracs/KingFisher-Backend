using FluentValidation;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Register.Models;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Validators;

public class LocationValidator : AbstractValidator<GPSPositionModel>
{
	public LocationValidator()
	{
		RuleFor(i => i.Latitude)
			.NotEmpty(); // need to write an extension for validate the precision or trim

		RuleFor(i => i.Longitude)
			.NotEmpty(); // need to write an extension for validate the precision or trim
	}
}
