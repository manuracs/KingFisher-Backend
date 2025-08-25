namespace KingFisher.Application.Handlers.Common.Responses;

public class ErrorResponse : BaseResponse
{
	public ErrorResponse(string? error) : base(false, error)
	{

	}
}
