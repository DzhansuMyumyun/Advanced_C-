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

namespace Application.Features.FuelTrues.Commands.Update;

public class UpdateFuelTrueCommand : IRequest<UpdatedFuelTrueResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, FuelTruesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFuelTrues"];

    public class UpdateFuelTrueCommandHandler : IRequestHandler<UpdateFuelTrueCommand, UpdatedFuelTrueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTrueRepository _fuelTrueRepository;
        private readonly FuelTrueBusinessRules _fuelTrueBusinessRules;

        public UpdateFuelTrueCommandHandler(IMapper mapper, IFuelTrueRepository fuelTrueRepository,
                                         FuelTrueBusinessRules fuelTrueBusinessRules)
        {
            _mapper = mapper;
            _fuelTrueRepository = fuelTrueRepository;
            _fuelTrueBusinessRules = fuelTrueBusinessRules;
        }

        public async Task<UpdatedFuelTrueResponse> Handle(UpdateFuelTrueCommand request, CancellationToken cancellationToken)
        {
            FuelTrue? fuelTrue = await _fuelTrueRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelTrueBusinessRules.FuelTrueShouldExistWhenSelected(fuelTrue);
            fuelTrue = _mapper.Map(request, fuelTrue);

            await _fuelTrueRepository.UpdateAsync(fuelTrue!);

            UpdatedFuelTrueResponse response = _mapper.Map<UpdatedFuelTrueResponse>(fuelTrue);
            return response;
        }
    }
}