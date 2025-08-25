﻿namespace KingFisher.Application.Contracts;

public interface IUnitOfWork
{
	Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
