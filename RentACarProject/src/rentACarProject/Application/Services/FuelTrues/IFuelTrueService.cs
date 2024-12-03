using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FuelTrues;

public interface IFuelTrueService
{
    Task<FuelTrue?> GetAsync(
        Expression<Func<FuelTrue, bool>> predicate,
        Func<IQueryable<FuelTrue>, IIncludableQueryable<FuelTrue, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FuelTrue>?> GetListAsync(
        Expression<Func<FuelTrue, bool>>? predicate = null,
        Func<IQueryable<FuelTrue>, IOrderedQueryable<FuelTrue>>? orderBy = null,
        Func<IQueryable<FuelTrue>, IIncludableQueryable<FuelTrue, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FuelTrue> AddAsync(FuelTrue fuelTrue);
    Task<FuelTrue> UpdateAsync(FuelTrue fuelTrue);
    Task<FuelTrue> DeleteAsync(FuelTrue fuelTrue, bool permanent = false);
}
