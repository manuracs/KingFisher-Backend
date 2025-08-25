using AutoMapper;
using KingFisher.Application.Contracts;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Repositories.Employees;
using KingFisher.Domain.Models.Employees;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Commands.Create;

public class Handler : BaseRequestHandler<Command>
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public Handler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
	{
		_employeeRepository = employeeRepository;
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public override async Task<BaseResponse> HandleAsync(Command request, CancellationToken cancellationToken)
	{
		var employee = _mapper.Map<Employee>(request);

		_employeeRepository.Add(employee);


		await _unitOfWork.CommitAsync(cancellationToken);

		return new CreatedResponse<Guid>(employee.Id);
	}
}
