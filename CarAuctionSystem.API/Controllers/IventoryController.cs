using CarAuctionSystem.Application.Vehicles.Commands.CreateHatchback;
using CarAuctionSystem.Application.Vehicles.Commands.CreateSedan;
using CarAuctionSystem.Application.Vehicles.Commands.CreateSUV;
using CarAuctionSystem.Application.Vehicles.Commands.CreateTruck;
using CarAuctionSystem.Application.Vehicles.Queries.GetVehicles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionSystem.API.Controllers;

[AllowAnonymous]
public class IventoryController : ApiControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<IventoryController> _logger;

    public IventoryController(
        ISender mediator,
        ILogger<IventoryController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> Search([FromQuery] GetVehiclesQuery request)
    {
        var queryResult = await _mediator.Send(request);

        return queryResult.Match(
            results => Ok(results),
            errors => Problem(errors));
    }


    [HttpPost]
    [Route("hatchback")]
    public async Task<IActionResult> CreateHatchback([FromBody] CreateHatchbackCommand request)
    {
        var createResult = await _mediator.Send(request);

        return createResult.Match(
            truck => Ok(truck),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("sedan")]
    public async Task<IActionResult> CreateSedan([FromBody] CreateSedanCommand request)
    {
        var createResult = await _mediator.Send(request);

        return createResult.Match(
            sedan => Ok(sedan),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("suv")]
    public async Task<IActionResult> CreateSUV([FromBody] CreateSUVCommand request)
    {
        var createResult = await _mediator.Send(request);

        return createResult.Match(
            suv => Ok(suv),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("truck")]
    public async Task<IActionResult> CreateTruck([FromBody] CreateTruckCommand request)
    {
        var createResult = await _mediator.Send(request);

        return createResult.Match(
            truck => Ok(truck),
            errors => Problem(errors));
    }
}
