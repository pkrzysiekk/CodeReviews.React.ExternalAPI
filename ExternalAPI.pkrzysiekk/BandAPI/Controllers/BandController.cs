using BandAPI.Models;
using BandAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BandAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BandController : ControllerBase
{
    private readonly IBandRepository  _bandRepository;
    public BandController( IBandRepository bandRepository)
    {
        _bandRepository = bandRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetBands()
    {
        var bands = await _bandRepository.GetBands() ?? new List<Band>();
        return Ok(bands);
    }
} 