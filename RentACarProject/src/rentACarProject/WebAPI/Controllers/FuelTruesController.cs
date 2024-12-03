using Application.Features.FuelTrues.Commands.Create;
using Application.Features.FuelTrues.Commands.Delete;
using Application.Features.FuelTrues.Commands.Update;
using Application.Features.FuelTrues.Queries.GetById;
using Application.Features.FuelTrues.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelTruesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFuelTrueResponse>> Add([FromBody] CreateFuelTrueCommand command)
    {
        CreatedFuelTrueResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedFuelTrueResponse>> Update([FromBody] UpdateFuelTrueCommand command)
    {
        UpdatedFuelTrueResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedFuelTrueResponse>> Delete([FromRoute] Guid id)
    {
        DeleteFuelTrueCommand command = new() { Id = id };

        DeletedFuelTrueResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdFuelTrueResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdFuelTrueQuery query = new() { Id = id };

        GetByIdFuelTrueResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListFuelTrueListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFuelTrueQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFuelTrueListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}