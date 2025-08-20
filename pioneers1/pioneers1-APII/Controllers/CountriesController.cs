using Microsoft.AspNetCore.Mvc;
using Pioneers.Application.DTOs;
using Pioneers.Infrastructure.Services;
namespace pioneers1_APII.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly CountryService _svc;
    public CountriesController(CountryService svc) => _svc = svc;

    [HttpGet] public async Task<IActionResult> Get() => Ok(await _svc.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
        => (await _svc.GetByIdAsync(id)) is { } x ? Ok(x) : NotFound();

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCountryDto dto)
    {
        var created = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateCountryDto dto)
    { if (id != dto.Id) return BadRequest(); return Ok(await _svc.UpdateAsync(dto)); }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    { await _svc.DeleteAsync(id); return NoContent(); }
}
