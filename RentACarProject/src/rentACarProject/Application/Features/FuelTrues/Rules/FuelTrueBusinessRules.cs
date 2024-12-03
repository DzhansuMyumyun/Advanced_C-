using Application.Features.FuelTrues.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FuelTrues.Rules;

public class FuelTrueBusinessRules : BaseBusinessRules
{
    private readonly IFuelTrueRepository _fuelTrueRepository;
    private readonly ILocalizationService _localizationService;

    public FuelTrueBusinessRules(IFuelTrueRepository fuelTrueRepository, ILocalizationService localizationService)
    {
        _fuelTrueRepository = fuelTrueRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FuelTruesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FuelTrueShouldExistWhenSelected(FuelTrue? fuelTrue)
    {
        if (fuelTrue == null)
            await throwBusinessException(FuelTruesBusinessMessages.FuelTrueNotExists);
    }

    public async Task FuelTrueIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        FuelTrue? fuelTrue = await _fuelTrueRepository.GetAsync(
            predicate: ft => ft.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FuelTrueShouldExistWhenSelected(fuelTrue);
    }
}