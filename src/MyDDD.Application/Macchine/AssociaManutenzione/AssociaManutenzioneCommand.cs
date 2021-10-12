using MyDDD.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Application.Macchine.AssociaManutenzione
{

  public class AssociaManutenzioneCommand : CommandBase<int>
  {
    public int IdMacchina { get;}
    public int IdManutenzione { get;}
    public AssociaManutenzioneCommand(int idMacchina, int idManutenzione)
    {
      IdMacchina = idMacchina;
      IdManutenzione = idManutenzione;
    }
  }
}
