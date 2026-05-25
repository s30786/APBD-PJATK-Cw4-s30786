using Microsoft.AspNetCore.Mvc;
using APBD_PJATK_Cw4_s30786.DTOs;
using APBD_PJATK_Cw4_s30786.Services;

namespace APBD_PJATK_Cw4_s30786.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _pcService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var result = await _pcService.GetComponentsByIdAsync(id);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PcPostRequestDto dto)
    {
        var response = await _pcService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = response.Id }, response);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcPutRequestDto dto)
    {
        var success = await _pcService.UpdateAsync(id, dto);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _pcService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
