using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FuelTrues.Queries.GetList;

public class GetListFuelTrueListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

}