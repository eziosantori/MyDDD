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
    private readonly IUnitOfWork uow;
    public MacchineRepository(
      IUnitOfWork unitOfWork)
    {
      uow = unitOfWork;
    }
    public async Task<IEnumerable<Macchina>> GetAll()
    {
        var sqlQuery = "SELECT top 10 id, antenato, idUo, icona, nome, categoria, notes, Matricola FROM Macchine";
        return await uow.QueryAsync<Macchina>(sqlQuery);
        
     
      // throw new NotImplementedException();
    }
    public async Task<Macchina> GetById(int Id)
    {
      var sqlQuery = "SELECT id, antenato, idUo, icona, nome, categoria, notes, Matricola FROM Macchine WHERE Id=@Id";
      return  await uow.QuerySingleOrDefaultAsync<Macchina>(sqlQuery, new { 
        Id
      });


      // throw new NotImplementedException();
    }

    public async Task<int> Update(Macchina macchina)
    {
        var sqlQuery = @"UPDATE Macchine SET 
        antenato=@antenato, idUo=@idUo, icona=@icona, nome=@nome, notes=@notes, categoria=@categoria, Matricola=@Matricola WHERE Id=@id";
        return await uow.ExecuteAsync(sqlQuery, macchina);    
    }
  }
}
