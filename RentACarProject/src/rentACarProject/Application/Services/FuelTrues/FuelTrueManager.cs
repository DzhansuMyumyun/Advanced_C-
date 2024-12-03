using Application.Features.FuelTrues.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FuelTrues;

public class FuelTrueManager : IFuelTrueService
{
    private readonly IFuelTrueRepository _fuelTrueRepository;
    private readonly FuelTrueBusinessRules _fuelTrueBusinessRules;

    public FuelTrueManager(IFuelTrueRepository fuelTrueRepository, FuelTrueBusinessRules fuelTrueBusinessRules)
    {
        _fuelTrueRepository = fuelTrueRepository;
        _fuelTrueBusinessRules = fuelTrueBusinessRules;
    }

    public async Task<FuelTrue?> GetAsync(
        Expression<Func<FuelTrue, bool>> predicate,
        Func<IQueryable<FuelTrue>, IIncludableQueryable<FuelTrue, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FuelTrue? fuelTrue = await _fuelTrueRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return fuelTrue;
    }

    public async Task<IPaginate<FuelTrue>?> GetListAsync(
        Expression<Func<FuelTrue, bool>>? predicate = null,
        Func<IQueryable<FuelTrue>, IOrderedQueryable<FuelTrue>>? orderBy = null,
        Func<IQueryable<FuelTrue>, IIncludableQueryable<FuelTrue, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FuelTrue> fuelTrueList = await _fuelTrueRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return fuelTrueList;
    }

    public async Task<FuelTrue> AddAsync(FuelTrue fuelTrue)
    {
        FuelTrue addedFuelTrue = await _fuelTrueRepository.AddAsync(fuelTrue);

        return addedFuelTrue;
    }

    public async Task<FuelTrue> UpdateAsync(FuelTrue fuelTrue)
    {
        FuelTrue updatedFuelTrue = await _fuelTrueRepository.UpdateAsync(fuelTrue);

        return updatedFuelTrue;
    }

    public async Task<FuelTrue> DeleteAsync(FuelTrue fuelTrue, bool permanent = false)
    {
        FuelTrue deletedFuelTrue = await _fuelTrueRepository.DeleteAsync(fuelTrue);

        return deletedFuelTrue;
    }
}
