using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyDDD.API.Core
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly string _connectionString;
    private readonly DbProvider _provider;
    private IDbConnection _connection;
    private IDbTransaction _transaction;
    public UnitOfWork(IConfiguration configuration)
    {
      _connectionString = configuration.GetConnectionString("Default");
      _provider = Enum.Parse<DbProvider>(configuration["ConnectionStrings:Provider"]);
      _connection = getConnection();
      _connection.Open();

    }
    IDbConnection getConnection()
    {
      if (_provider == DbProvider.Oracle)
        return new OracleConnection(_connectionString);

      return new SqlConnection(_connectionString);
    }
    public IDbConnection Connection { get => _connection; }
    public IDbTransaction Transaction { get => _transaction; }
    public void BeginTran()
    {
      _transaction = _connection?.BeginTransaction();
    }
  
    public void Commit()
          => _transaction?.Commit();

    public void Rollback()
      => _transaction?.Rollback();

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    ~UnitOfWork()
      => Dispose(false);

    protected virtual void Dispose(bool disposing)
    {

      if (disposing)
      {
        _transaction?.Dispose();
        _connection?.Dispose();
      }

      _transaction = null;
      _connection = null;

    }
    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
    {
      return _connection.QueryAsync<T>(sql, param, _transaction);
    }
    public Task<int> ExecuteAsync(string sql, object param = null)
    {
      return _connection.ExecuteAsync(sql, param, _transaction);

    }

    public Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null)
    {
      return _connection.QuerySingleOrDefaultAsync<T>(sql, param, _transaction);

    }
  }
}
