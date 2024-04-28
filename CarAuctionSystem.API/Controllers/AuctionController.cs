using AutoMapper;
using CarAuctionSystem.Application.Auctions.Commands.CloseAuction;
using CarAuctionSystem.Application.Auctions.Commands.StartAuction;
using CarAuctionSystem.Application.Bids.Commands.CreateBid;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionSystem.API.Controllers;

[AllowAnonymous]
public class AuctionController : ApiControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<AuctionController> _logger;

    public AuctionController(
        ISender mediator,
        IMapper mapper,
        ILogger<AuctionController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    [Route("start")]
    public async Task<IActionResult> StartAuction([FromBody] StartAuctionCommand request)
    {
        var sendResult = await _mediator.Send(request);

        return sendResult.Match(
            auction => Ok(auction),
            errors => Problem(errors));
    }

    [HttpPut]
    [Route("close")]
    public async Task<IActionResult> StopAuction([FromBody] CloseAuctionCommand request)
    {
        var sendResult = await _mediator.Send(request);

        return sendResult.Match(
            auction => Ok(auction),
            errors => Problem(errors));
    }

    [HttpPut]
    [Route("bid")]
    public async Task<IActionResult> Bid([FromBody] CreateBidCommand request)
    {
        var auction = await _mediator.Send(request);

        return auction.Match(
            bid => Ok(bid),
            errors => Problem(errors));
    }
}
