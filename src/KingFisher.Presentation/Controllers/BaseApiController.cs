using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace KingFisher.Presentation.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class BaseApiController : ControllerBase
{
	protected Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
	{
		ArgumentNullException.ThrowIfNull(request);

		return HttpContext.RequestServices.GetRequiredService<IMediator>().Send(request, HttpContext.RequestAborted);
	}
}
