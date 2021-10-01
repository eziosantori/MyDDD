using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.Domain.Macchine
{
  public class Macchina
  {
    public int id { get; set; }
    public int? antenato { get; set; }
    public int idUo { get; set; }
    public int icona { get; set; }
    public string nome { get; set; }
    public string categoria { get; set; }
    public string notes { get; set; }
    public string Matricola { get; set; }
  }
}
