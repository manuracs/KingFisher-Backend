namespace KingFisher.Application.Handlers.Common.Responses;

public abstract class ListResponse<T> : SuccessResponse
	where T : new()
{
	protected ListResponse()
	{
		Items = [];
	}

	protected ListResponse(IEnumerable<T> items)
	{
		Items = items as IList<T> ?? [.. items];
	}

	protected ListResponse(List<T> items)
	{
		Items = items;
	}

	protected ListResponse(IList<T> items)
	{
		Items = items;
	}

	public IList<T> Items { get; init; }
}
