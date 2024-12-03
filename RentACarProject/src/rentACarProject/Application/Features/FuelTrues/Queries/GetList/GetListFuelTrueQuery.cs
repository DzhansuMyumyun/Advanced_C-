using Application.Features.FuelTrues.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.FuelTrues.Constants.FuelTruesOperationClaims;

namespace Application.Features.FuelTrues.Queries.GetList;

public class GetListFuelTrueQuery : IRequest<GetListResponse<GetListFuelTrueListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListFuelTrues({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetFuelTrues";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListFuelTrueQueryHandler : IRequestHandler<GetListFuelTrueQuery, GetListResponse<GetListFuelTrueListItemDto>>
    {
        private readonly IFuelTrueRepository _fuelTrueRepository;
        private readonly IMapper _mapper;

        public GetListFuelTrueQueryHandler(IFuelTrueRepository fuelTrueRepository, IMapper mapper)
        {
            _fuelTrueRepository = fuelTrueRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFuelTrueListItemDto>> Handle(GetListFuelTrueQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FuelTrue> fuelTrues = await _fuelTrueRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFuelTrueListItemDto> response = _mapper.Map<GetListResponse<GetListFuelTrueListItemDto>>(fuelTrues);
            return response;
        }
    }
}