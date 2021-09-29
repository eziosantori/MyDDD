using MyDDD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.API.Repository
{
  public interface IMacchineRepository
  {
    Task<IEnumerable<Macchina>> GetAll();
    Task<Macchina> GetById(int Id);
    Task<int> Update(Macchina macchina);
    
  }
}
