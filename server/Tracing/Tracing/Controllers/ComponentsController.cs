using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin")]
public class ComponentsController : ControllerBase
{
    private readonly IComponentsService _componentsService;
    private readonly IMapper _mapper;

    public ComponentsController(IComponentsService componentsService, IMapper mapper)
    {
        _componentsService = componentsService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ComponentsDto>> GetAllComponents()
    {
        var response = await _componentsService.GetComponents();
        return Ok(response);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<ComponentsHistory>> GetComponentHistory(Guid id)
    {
        var comp = await _componentsService.GetComponentHistory(id);

        if (comp != null)
        {
            return Ok(comp);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ConmponentsAdded>> AddComponents(AddComponentsDto components)
    {
        var res = await _componentsService.AddComponents(components);

        if (res == "component added")
        {
            var comp = new ConmponentsAdded()
            {
                ComponentsResponse = res,
                Success = true,
            };

            return Ok(comp);
        }

        return BadRequest(); 
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ComponentsDto>> UpdateComponents(Guid id, AddComponentsDto components)
    {
        return Ok(await _componentsService.UpdateComponents(id, components));
    }
}
