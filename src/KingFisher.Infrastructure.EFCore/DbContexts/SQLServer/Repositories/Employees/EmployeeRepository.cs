using KingFisher.Application.Repositories.Employees;
using KingFisher.Domain.Models.Employees;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer.Repositories.Employees;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
	public EmployeeRepository(SQLServerDBContext context) : base(context)
	{
	}
}
