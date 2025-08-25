using KingFisher.Application.Handlers.Common.Responses;
using MediatR;

namespace KingFisher.Application.Handlers.Common;

public abstract class BaseRequestHandler<T> : IRequestHandler<T, BaseResponse> where T : class, Requests.IBaseRequest
{
	public Task<BaseResponse> Handle(T request, CancellationToken cancellationToken) => HandleAsync(request, cancellationToken);

	public abstract Task<BaseResponse> HandleAsync(T request, CancellationToken cancellationToken);
}
