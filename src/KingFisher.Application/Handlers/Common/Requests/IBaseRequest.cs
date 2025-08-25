using KingFisher.Application.Handlers.Common.Responses;
using MediatR;

namespace KingFisher.Application.Handlers.Common.Requests;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "marker interface")]
public interface IBaseRequest : IRequest<BaseResponse>
{
}
