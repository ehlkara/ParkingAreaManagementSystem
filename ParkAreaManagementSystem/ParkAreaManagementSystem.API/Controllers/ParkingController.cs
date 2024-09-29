using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkAreaManagementSystem.Application.Commands.ParkVehicle;
using ParkAreaManagementSystem.Application.Queries.ParkVehicle;
using ParkAreaManagementSystem.Domain.Entities;

namespace ParkAreaManagementSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParkingController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParkingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("park")]
    public async Task<IActionResult> ParkVehicle([FromBody] ParkVehicleCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableParkingSpots([FromQuery] VehicleSize size)
    {
        var query = new GetAvailableParkingSpotsQuery(size);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
