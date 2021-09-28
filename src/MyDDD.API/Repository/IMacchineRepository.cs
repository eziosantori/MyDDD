using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.API.Repository
{
  public interface IMacchineRepository
  {
    Task<IEnumerable<Models.Macchina>> GetAll();
    
  }
}
