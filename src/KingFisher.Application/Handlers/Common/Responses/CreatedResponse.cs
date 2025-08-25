namespace KingFisher.Application.Handlers.Common.Responses;

public class CreatedResponse : SuccessResponse
{
}

public class CreatedResponse<T> : CreatedResponse
	where T : IEquatable<T>
{
	public CreatedResponse(T id)
	{
		Id = id;
	}

	public T Id { get; init; }
}
