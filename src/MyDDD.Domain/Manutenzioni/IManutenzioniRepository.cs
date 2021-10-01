using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.Domain.Manutenzioni
{
  public interface IManutenzioniRepository
  {
    Task<IEnumerable<Manutenzione>> GetAll();
    Task<Manutenzione> GetById(int Id);
    Task<int> Update(Manutenzione item);
  }
}
