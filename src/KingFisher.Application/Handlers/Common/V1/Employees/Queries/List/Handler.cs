using AutoMapper;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Handlers.Common.V1.Employees.Queries.List.Models;
using KingFisher.Application.Queries.Employees;

namespace KingFisher.Application.Handlers.Common.V1.Employees.Queries.List;

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
		var employees = await _employeeQuery.GetAllAsync(cancellationToken).ConfigureAwait(false);

		var items = _mapper.Map<List<EmployeeModel>>(employees);

		return new Response(items);
	}
}
