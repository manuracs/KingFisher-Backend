using FluentValidation;
using KingFisher.Domain.Common.Constants;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Commands.Create;

public class Validator : AbstractValidator<Command>
{
	public Validator()
	{
		RuleFor(i => i.FirstName)
			.NotEmpty()
			.MaximumLength(DomainConstants.PersonNames.FirstNameLength);// need to know if there are any pattern to validate on name.

		RuleFor(i => i.LastName)
			.NotEmpty()
			.MaximumLength(DomainConstants.PersonNames.LastNameLength);// need to know if there are any pattern to validate on name.

		RuleFor(i => i.ProfileImageURL)
			.NotEmpty()
			.MaximumLength(DomainConstants.Employees.EmailLength)
			.Matches(@"^(https?://)?([\da-z\.-]+\.[a-z\.]{2,6})([/\w \.-]*)*/?$");

		RuleFor(x => x.DateOfBirth)
		   .NotEmpty().WithMessage("Date of birth is required.")
		   .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.")
		   .Must(BeAtLeast18YearsOld).WithMessage("Employee must be at least 18 years old.");
	}

	private bool BeAtLeast18YearsOld(DateTime birthDate)
	{
		return birthDate <= DateTime.Today.AddYears(-18);
	}

}
