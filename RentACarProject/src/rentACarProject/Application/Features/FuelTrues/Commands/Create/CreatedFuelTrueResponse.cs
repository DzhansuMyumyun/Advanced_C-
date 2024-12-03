using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTrues.Commands.Create;

public class CreatedFuelTrueResponse : IResponse
{
    public Guid Id { get; set; }
}