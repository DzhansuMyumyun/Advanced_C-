using Application.Features.FuelTrues.Constants;
using Application.Features.FuelTrues.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelTrues.Constants.FuelTruesOperationClaims;

namespace Application.Features.FuelTrues.Queries.GetById;

public class GetByIdFuelTrueQuery : IRequest<GetByIdFuelTrueResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdFuelTrueQueryHandler : IRequestHandler<GetByIdFuelTrueQuery, GetByIdFuelTrueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTrueRepository _fuelTrueRepository;
        private readonly FuelTrueBusinessRules _fuelTrueBusinessRules;

        public GetByIdFuelTrueQueryHandler(IMapper mapper, IFuelTrueRepository fuelTrueRepository, FuelTrueBusinessRules fuelTrueBusinessRules)
        {
            _mapper = mapper;
            _fuelTrueRepository = fuelTrueRepository;
            _fuelTrueBusinessRules = fuelTrueBusinessRules;
        }

        public async Task<GetByIdFuelTrueResponse> Handle(GetByIdFuelTrueQuery request, CancellationToken cancellationToken)
        {
            FuelTrue? fuelTrue = await _fuelTrueRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelTrueBusinessRules.FuelTrueShouldExistWhenSelected(fuelTrue);

            GetByIdFuelTrueResponse response = _mapper.Map<GetByIdFuelTrueResponse>(fuelTrue);
            return response;
        }
    }
}