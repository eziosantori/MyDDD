using MyDDD.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Application.Macchine.UpdateNote
{
  public class UpdateNoteCommand: CommandBase<int>
  {
    public int IdMacchina { get; set; }
    public string Nota { get; set; }
    public UpdateNoteCommand(int idMacchina, string nota)
    {
      IdMacchina = idMacchina;
      Nota = nota;
    }
  }
}
