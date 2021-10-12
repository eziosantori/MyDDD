using MyDDD.Domain.Core;
using MyDDD.Domain.Manutenzioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Infrastucture.Manutenzioni
{
  public class ManutenzioniRepository : IManutenzioniRepository
  {
    private readonly IUnitOfWork uow;

    public ManutenzioniRepository(IUnitOfWork unitOfWork)
    {
      uow = unitOfWork;
    }
  public Task<int> AssociaManutenzione(int idMacchina, int idManutenzione)
  {
      throw new NotImplementedException();
  }

    public Task<IEnumerable<Manutenzione>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<Manutenzione> GetById(int Id)
    {
      throw new NotImplementedException();
    }

    public Task<int> Update(Manutenzione item)
    {
      throw new NotImplementedException();
    }
  }
}
