using KingFisher.Application.Queries.Employees;
using KingFisher.Domain.Models.Employees;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.Queries.Employees;

public class EmployeeQuery : EntityQuery<Employee>, IEmployeeQuery
{
	public EmployeeQuery(SQLServerDBContext context) : base(context)
	{
	}
}
