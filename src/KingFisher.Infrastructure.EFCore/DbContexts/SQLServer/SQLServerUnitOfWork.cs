using KingFisher.Application.Contracts;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer;

public class SQLServerUnitOfWork(SQLServerDBContext context) : IUnitOfWork
{
	private readonly SQLServerDBContext _context = context ?? throw new ArgumentNullException(nameof(context));

	public virtual async Task<int> CommitAsync(CancellationToken cancellationToken = default)
	{
		return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
