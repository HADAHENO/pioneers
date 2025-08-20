using Microsoft.AspNetCore.Mvc;
using Pioneers.Application.DTOs;
using Pioneers.Infrastructure.Services;

namespace pioneers1_APII.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly CityService _svc;
    public CitiesController(CityService svc) => _svc = svc;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _svc.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await _svc.GetByIdAsync(id)) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCityDto dto)
    {
        var created = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateCityDto dto)
    {
        if (id != dto.Id) return BadRequest();
        return Ok(await _svc.UpdateAsync(dto));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _svc.DeleteAsync(id);
        return NoContent();
    }
}

