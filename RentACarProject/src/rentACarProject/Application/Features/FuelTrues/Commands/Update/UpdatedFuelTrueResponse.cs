using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTrues.Commands.Update;

public class UpdatedFuelTrueResponse : IResponse
{
    public Guid Id { get; set; }
}