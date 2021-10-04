using MediatR;
using MyDDD.Application.Configuration.Commands;
using MyDDD.Domain.Core;
using MyDDD.Domain.Macchine.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDDD.Application.Macchine.UpdateNote
{
  public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand, int>
  {

    private readonly IUnitOfWork _unitofWork;
    private readonly IMacchineRepository _repoMacchine;

    public UpdateNoteCommandHandler(
      IUnitOfWork unitofWork,
      IMacchineRepository repoMacchine
     )
    {
      _unitofWork = unitofWork;
      _repoMacchine = repoMacchine;
    }

    public async Task<int> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
      // TODO, convertire la unit of work in un decorator
      _unitofWork.BeginTran();
      var macchina = await _repoMacchine.GetById(request.IdMacchina);

      macchina.notes = request.Nota;
      // macchina.Matricola = body.Matricola;
      // await _repoMacchine.GetA();
      var esito = await _repoMacchine.Update(macchina);

      _unitofWork.Commit();

      return esito;
    }
  }
}
