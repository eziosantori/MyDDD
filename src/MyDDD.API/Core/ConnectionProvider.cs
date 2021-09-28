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
  public class ConnectionProvider : IConnectionProvider
  {
    private readonly string _connectionString;
    private readonly DbProvider _provider;
    public ConnectionProvider(IConfiguration configuration)
    {
      _connectionString = configuration.GetConnectionString("Default");
      _provider = Enum.Parse<DbProvider>(configuration["ConnectionStrings:Provider"]);
    }

    public DbProvider Provider { get; private set; }

    public IDbConnection GetConnection()
    {
      if (_provider == DbProvider.Oracle)
        return new OracleConnection(_connectionString);

      return new SqlConnection(_connectionString);
    }
  }
}
