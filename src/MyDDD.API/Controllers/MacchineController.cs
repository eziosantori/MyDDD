using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDDD.API.Core;
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
    private readonly IUnitOfWork _unitofWork;
    private readonly IMacchineRepository _repoMacchine;

    public MacchineController(
      ILogger<MacchineController> logger,
      IUnitOfWork unitofWork,
      IMacchineRepository repoMacchine
      )
    {
      _logger = logger;
      _unitofWork = unitofWork;
      _repoMacchine = repoMacchine;
    }

    [HttpGet]
    public async Task<IEnumerable<Macchina>> Get()
    {
      return await _repoMacchine.GetAll();
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<Macchina> GetById(int id)
    {
      return await _repoMacchine.GetById(id);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<int> Put([FromRoute]int id, [FromBody] Macchina body)
    {
       // simuliamo transazione
      _unitofWork.BeginTran();
      var macchina = await _repoMacchine.GetById(id);

      macchina.notes = body.notes;
      macchina.Matricola = body.Matricola;
      // await _repoMacchine.GetA();
      var esito = await _repoMacchine.Update(macchina);

      _unitofWork.Commit();

      var res = await _repoMacchine.GetById(id);
      return esito;
    }
  }
}
