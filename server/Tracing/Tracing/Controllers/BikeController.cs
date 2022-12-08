using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin")]
public class BikeController : ControllerBase
{
    private readonly IBikeService _bikeService;
    public BikeController(IBikeService bikeService)
    { 
        _bikeService = bikeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bike>>> GetBikes()
    {
        return Ok(await _bikeService.GetBikes());
    }
        
    [HttpPost]
    public async Task<ActionResult<BikeResponse>> GetAllBikes(BikeDto bike)
    {
        var response = await _bikeService.AddBikes(bike);
        var bikeResp = new BikeResponse
        {
            bikeResponse = response
        }; 
        return Ok(bikeResp);
    }
}

