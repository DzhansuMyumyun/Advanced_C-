using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTrues.Queries.GetById;

public class GetByIdFuelTrueResponse : IResponse
{
    public Guid Id { get; set; }
}