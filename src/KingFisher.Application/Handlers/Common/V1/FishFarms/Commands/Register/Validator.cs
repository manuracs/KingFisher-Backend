using FluentValidation;
using KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Validators;
using KingFisher.Domain.Common.Constants;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Register;

public class Validator : AbstractValidator<Command>
{
	public Validator()
	{
		RuleFor(i => i.FarmName)
			.NotEmpty()
			.MaximumLength(DomainConstants.FishFarms.FarmNameLength);// need to know if there are any pattern to validate on name.

		RuleFor(i => i.FarmImageURL)
			.NotEmpty()
			.MaximumLength(DomainConstants.FishFarms.FarmImageURLLength)
			.Matches(@"^(https?://)?([\da-z\.-]+\.[a-z\.]{2,6})([/\w \.-]*)*/?$");

		RuleFor(i => i.GPSPosition)
			.NotEmpty()
			.SetValidator(new LocationValidator());
	}
}
