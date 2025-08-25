namespace KingFisher.Application.Handlers.Common.Responses;

public abstract class BaseResponse
{
	protected BaseResponse(bool isSuccess, string? error)
	{
		if (!isSuccess && string.IsNullOrWhiteSpace(error))
		{
			throw new ArgumentException("Error must be provided when IsSuccess is false.", nameof(error));
		}

		if (isSuccess && !string.IsNullOrWhiteSpace(error))
		{
			throw new ArgumentException("Error must be empty when IsSuccess is true.", nameof(error));
		}

		IsSuccess = isSuccess;
		Error = error;
	}

	public bool IsSuccess { get; }

	public string? Error { get; }

}
