using Application.Features.FuelTrues.Constants;
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

namespace Application.Features.FuelTrues.Commands.Delete;

public class DeleteFuelTrueCommand : IRequest<DeletedFuelTrueResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, FuelTruesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFuelTrues"];

    public class DeleteFuelTrueCommandHandler : IRequestHandler<DeleteFuelTrueCommand, DeletedFuelTrueResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTrueRepository _fuelTrueRepository;
        private readonly FuelTrueBusinessRules _fuelTrueBusinessRules;

        public DeleteFuelTrueCommandHandler(IMapper mapper, IFuelTrueRepository fuelTrueRepository,
                                         FuelTrueBusinessRules fuelTrueBusinessRules)
        {
            _mapper = mapper;
            _fuelTrueRepository = fuelTrueRepository;
            _fuelTrueBusinessRules = fuelTrueBusinessRules;
        }

        public async Task<DeletedFuelTrueResponse> Handle(DeleteFuelTrueCommand request, CancellationToken cancellationToken)
        {
            FuelTrue? fuelTrue = await _fuelTrueRepository.GetAsync(predicate: ft => ft.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelTrueBusinessRules.FuelTrueShouldExistWhenSelected(fuelTrue);

            await _fuelTrueRepository.DeleteAsync(fuelTrue!);

            DeletedFuelTrueResponse response = _mapper.Map<DeletedFuelTrueResponse>(fuelTrue);
            return response;
        }
    }
}