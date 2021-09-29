using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.API.Models
{
  public class Manutenzione
  {
    public int id { get; set; }
    public int? antenato { get; set; }
    public int periodo { get; set; }
    public int periodoUM { get; set; }
    public int icona { get; set; }
    public string nome { get; set; }
    public string Codice { get; set; }
    public string notes { get; set; }
  }
}
