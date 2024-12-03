using Application.Features.FuelTrues.Constants;
using Application.Features.FuelTrues.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FuelTrues.Constants.FuelTruesOperationClaims;

namespace Application.Features.FuelTrues.Commands.Create;

public class CreateFuelTrueCommand : IRequest<CreatedFuelTrueResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, FuelTruesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFuelTrues"];

    public class CreateFuelTrueCommandHandler : IRequestHandler<CreateFuelTrueCommand, CreatedFuelTrueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTrueRepository _fuelTrueRepository;
        private readonly FuelTrueBusinessRules _fuelTrueBusinessRules;

        public CreateFuelTrueCommandHandler(IMapper mapper, IFuelTrueRepository fuelTrueRepository,
                                         FuelTrueBusinessRules fuelTrueBusinessRules)
        {
            _mapper = mapper;
            _fuelTrueRepository = fuelTrueRepository;
            _fuelTrueBusinessRules = fuelTrueBusinessRules;
        }

        public async Task<CreatedFuelTrueResponse> Handle(CreateFuelTrueCommand request, CancellationToken cancellationToken)
        {
            FuelTrue fuelTrue = _mapper.Map<FuelTrue>(request);

            await _fuelTrueRepository.AddAsync(fuelTrue);

            CreatedFuelTrueResponse response = _mapper.Map<CreatedFuelTrueResponse>(fuelTrue);
            return response;
        }
    }
}