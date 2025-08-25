using AutoMapper;
using KingFisher.Application.Contracts;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Queries.Employees;
using KingFisher.Application.Queries.FishFarms;
using KingFisher.Application.Repositories.FishFarms;
using KingFisher.Domain.Models.FishFarms;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.WorkerAssign;

public class Handler : BaseRequestHandler<Command>
{
	private readonly IEmployeeQuery _employeeQuery;
	private readonly IFishFarmQuery _farmQuery;
	private readonly IFishFarmRepository _farmRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public Handler(
		IEmployeeQuery employeeQuery,
		IFishFarmQuery farmQuery,
		IFishFarmRepository farmRepository,
		IUnitOfWork unitOfWork,
		IMapper mapper)
	{
		_employeeQuery = employeeQuery;
		_farmQuery = farmQuery;
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_farmRepository = farmRepository;
	}

	public override async Task<BaseResponse> HandleAsync(Command request, CancellationToken cancellationToken)
	{
		var employee = await _employeeQuery.GetEntityByIdAsync(request.EmployeeId, cancellationToken: cancellationToken).ConfigureAwait(false);

		if (employee == null)
		{
			return new ErrorResponse("Employee not found");
		}

		var fishFarm = await _farmQuery.GetEntityByIdAsync(request.FishFarmId, cancellationToken: cancellationToken).ConfigureAwait(false);

		if (fishFarm is null)
		{
			return new ErrorResponse("Fish farm not found.");
		}

		// need another validation if employee is already assigned for the given period. Then change only the assignment. Skipping for now.

		var item = _mapper.Map<FishFarmEmployee>(request);

		fishFarm.Add(item);

		_farmRepository.Attach(fishFarm);

		await _unitOfWork.CommitAsync(cancellationToken);

		return new SuccessResponse();
	}
}
