using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTrues.Commands.Delete;

public class DeletedFuelTrueResponse : IResponse
{
    public Guid Id { get; set; }
}