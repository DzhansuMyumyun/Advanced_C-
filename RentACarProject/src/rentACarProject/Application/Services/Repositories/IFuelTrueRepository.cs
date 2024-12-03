using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFuelTrueRepository : IAsyncRepository<FuelTrue, Guid>, IRepository<FuelTrue, Guid>
{
}