using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyDDD.API.Core
{
  public interface IUnitOfWork: IDisposable
  {
    /// <summary>
    /// Torana una connessione già aperta
    /// </summary>
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; }
    /// <summary>
    /// Wrapper del metodo di Dapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
    Task<int> ExecuteAsync(string sql, object param = null);
    Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null);
    void BeginTran();
    void Commit();
    void Rollback();
  }
}