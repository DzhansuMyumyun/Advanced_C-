using Application.Features.FuelTrues.Commands.Create;
using Application.Features.FuelTrues.Commands.Delete;
using Application.Features.FuelTrues.Commands.Update;
using Application.Features.FuelTrues.Queries.GetById;
using Application.Features.FuelTrues.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FuelTrues.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFuelTrueCommand, FuelTrue>();
        CreateMap<FuelTrue, CreatedFuelTrueResponse>();

        CreateMap<UpdateFuelTrueCommand, FuelTrue>();
        CreateMap<FuelTrue, UpdatedFuelTrueResponse>();

        CreateMap<DeleteFuelTrueCommand, FuelTrue>();
        CreateMap<FuelTrue, DeletedFuelTrueResponse>();

        CreateMap<FuelTrue, GetByIdFuelTrueResponse>();

        CreateMap<FuelTrue, GetListFuelTrueListItemDto>();
        CreateMap<IPaginate<FuelTrue>, GetListResponse<GetListFuelTrueListItemDto>>();
    }
}