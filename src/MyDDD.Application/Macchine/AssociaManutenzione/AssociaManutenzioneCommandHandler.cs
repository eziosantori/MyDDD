﻿using MyDDD.Application.Configuration.Commands;
using MyDDD.Domain.Core;
using MyDDD.Domain.Macchine.Repository;
using MyDDD.Domain.Manutenzioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace MyDDD.Application.Macchine.AssociaManutenzione
{

  public class AssociaManutenzioneCommandHandler : ICommandHandler<AssociaManutenzioneCommand, int>
  {

    private readonly IUnitOfWork _unitofWork;
    private readonly IMacchineRepository _repoMacchine;
    private readonly IManutenzioniRepository _repoManutenzioni;

    public AssociaManutenzioneCommandHandler(
      IUnitOfWork unitofWork,
      IMacchineRepository repoMacchine,
      IManutenzioniRepository repoManutenzioni
     )
    {
      _unitofWork = unitofWork;
      _repoMacchine = repoMacchine;
      _repoManutenzioni = repoManutenzioni;
    }

    public async Task<int> Handle(AssociaManutenzioneCommand request, CancellationToken cancellationToken)
    {
      // TODO, convertire 
      using (var ts = new TransactionScope())
      {
        var macchina = await _repoMacchine.GetById(request.IdMacchina);

        macchina.notes = "Simuliamo transazione su più repo";
        // macchina.Matricola = body.Matricola;
        // await _repoMacchine.GetA();
        var esito = await _repoMacchine.Update(macchina);
        // _unitofWork.ExecuteAsync("")
        ts.Complete();
        _unitofWork.Commit();
        return esito;
      }
    }
  }
}
