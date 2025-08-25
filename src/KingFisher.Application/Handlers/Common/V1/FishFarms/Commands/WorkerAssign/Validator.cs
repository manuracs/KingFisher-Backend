using FluentValidation;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.WorkerAssign;

public class Validator : AbstractValidator<Command>
{
	public Validator()
	{
		RuleFor(i => i.EmployeeId).NotEmpty();
		RuleFor(i => i.FishFarmId).NotEmpty();

		RuleFor(x => x.CertificationExpiryDate)
		   .NotEmpty()
		   .GreaterThan(DateTime.Today);
	}
}
