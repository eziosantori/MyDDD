using Microsoft.Extensions.Configuration;
using MyDDD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace MyDDD.API.Repository
{
  public class MacchineRepository : IMacchineRepository
  {
    private readonly string _connectionString;
    public MacchineRepository(IConfiguration configuration)
    {
      _connectionString = configuration.GetConnectionString("Default");
    }
    public async Task<IEnumerable<Macchina>> GetAll()
    {

        var sqlQuery = "SELECT top 10 id, antenato, idUo, icona, nome, categoria, notes, Matricola FROM Macchine";

        using (var connection = new SqlConnection(_connectionString))
        {
          return await connection.QueryAsync<Models.Macchina>(sqlQuery);
        }
     
      // throw new NotImplementedException();
    }
  }
}
