using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.Domain.Manutenzioni
{
  public class Manutenzione
  {
    public int id { get; internal set; }
    public int? antenato { get; internal set; }
    public int periodo { get; internal set; }
    public int periodoUM { get; internal set; }
    public int icona { get; internal set; }
    public string nome { get; internal set; }
    public string Codice { get; internal set; }
    public string notes { get; internal set; }

    public static Manutenzione Create(int periodo, int periodoUM, string nome, string codice, int? antenato=null)
    {
      return new Manutenzione
      {
        antenato = antenato,
        periodo = periodo,
        periodoUM = periodoUM,
        nome = nome,
        Codice = codice
      };
    }
  }
}
