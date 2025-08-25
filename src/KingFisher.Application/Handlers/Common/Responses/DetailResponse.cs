namespace KingFisher.Application.Handlers.Common.Responses;

public class DetailResponse<T> : SuccessResponse
	where T : new()
{
	public DetailResponse(T item)
	{
		Item = item;
	}

	public T Item { get; set; }
}
