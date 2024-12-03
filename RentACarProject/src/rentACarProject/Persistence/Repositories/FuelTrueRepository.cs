using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FuelTrueRepository : EfRepositoryBase<FuelTrue, Guid, BaseDbContext>, IFuelTrueRepository
{
    public FuelTrueRepository(BaseDbContext context) : base(context)
    {
    }
}