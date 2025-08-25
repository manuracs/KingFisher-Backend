using AutoMapper;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.Employees.Queries.Details.Models;
using KingFisher.Application.Queries.Employees;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Queries.Details;

public class Handler : BaseRequestHandler<Query>
{
	private readonly IEmployeeQuery _employeeQuery;
	private readonly IMapper _mapper;

	public Handler(IEmployeeQuery employeeQuery, IMapper mapper)
	{
		_employeeQuery = employeeQuery;
		_mapper = mapper;
	}

	public override async Task<BaseResponse> HandleAsync(Query request, CancellationToken cancellationToken)
	{
		var employee = await _employeeQuery.GetEntityByIdAsync(request.EmployeeId, cancellationToken: cancellationToken).ConfigureAwait(false);

		if (employee == null)
		{
			return new ErrorResponse("Employee not found");
		}

		var item = _mapper.Map<EmployeeModel>(employee);

		return new Response(item);
	}
}
