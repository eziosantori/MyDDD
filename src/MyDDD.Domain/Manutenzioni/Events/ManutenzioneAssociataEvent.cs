using MyDDD.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Domain.Manutenzioni.Events
{
  public class ManutenzioneAssociataEvent: DomainEventBase
  {
    public int IdMacchina { get;}
    public int IdManutenzione { get;}
    public ManutenzioneAssociataEvent(int idMacchina, int idManutenzione)
    {
      IdMacchina = idMacchina;
      IdManutenzione = idManutenzione;
    }
  }
}
