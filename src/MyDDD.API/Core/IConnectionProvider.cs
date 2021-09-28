using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.API.Core
{
  public interface IConnectionProvider
  {
    DbProvider Provider { get; }
    IDbConnection GetConnection();
  }
}
