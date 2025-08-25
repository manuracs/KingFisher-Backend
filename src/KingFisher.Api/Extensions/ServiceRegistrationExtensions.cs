using KingFisher.Application.Handlers.Common.Responses;

namespace KingFisher.Api.Extensions;

public static class ServiceRegistrationExtensions
{
	public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAutoMapper(typeof(BaseResponse).Assembly);
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BaseResponse).Assembly));
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
	}
}
