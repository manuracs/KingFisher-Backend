using AutoMapper;
using KingFisher.Application.Contracts;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.Application.Repositories.FishFarms;
using KingFisher.Domain.Models.FishFarms;

namespace KingFisher.Application.Handlers.Common.V1.FishFarms.Commands.Register;

public class Handler : BaseRequestHandler<Command>
{
	private readonly IFishFarmRepository _fishFarmRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public Handler(
		IFishFarmRepository fishFarmRepository,
		IUnitOfWork unitOfWork,
		IMapper mapper)
	{
		_fishFarmRepository = fishFarmRepository;
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public override async Task<BaseResponse> HandleAsync(Command request, CancellationToken cancellationToken)
	{
		// Here we need to check access rights for farm create. else return forbidden.

		var fishFarm = _mapper.Map<FishFarm>(request);

		_fishFarmRepository.Add(fishFarm);

		await _unitOfWork.CommitAsync(cancellationToken);

		return new CreatedResponse<Guid>(fishFarm.Id);
	}
}
