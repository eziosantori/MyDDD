using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDDD.API.Models;
using MyDDD.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MacchineController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<MacchineController> _logger;
    private readonly IMacchineRepository _repoMacchine;

    public MacchineController(
      ILogger<MacchineController> logger,
      IMacchineRepository repoMacchine
      )
    {
      _logger = logger;
      _repoMacchine = repoMacchine;
    }

    [HttpGet]
    public async Task<IEnumerable<Macchina>> Get()
    {
      return await _repoMacchine.GetAll();
    }
    [HttpPut]
    [Route("{id}")]
    public async Task Put([FromRoute]int id, [FromBody] Macchina body)
    {
      // await _repoMacchine.GetA();
      await _repoMacchine.Update(body);
    }
  }
}
