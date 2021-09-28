using Microsoft.Extensions.Configuration;
using MyDDD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using MyDDD.API.Core;

namespace MyDDD.API.Repository
{
  public class MacchineRepository : IMacchineRepository
  {
    private readonly IConnectionProvider _connectionProvider;
    public MacchineRepository(
      IConfiguration configuration, 
      IConnectionProvider connectionProvider)
    {
      _connectionProvider = connectionProvider;
    }
    public async Task<IEnumerable<Macchina>> GetAll()
    {

        var sqlQuery = "SELECT top 10 id, antenato, idUo, icona, nome, categoria, notes, Matricola FROM Macchine";

        using (var connection = _connectionProvider.GetConnection())
        {
          return await connection.QueryAsync<Models.Macchina>(sqlQuery);
        }
     
      // throw new NotImplementedException();
    }
  }
}
