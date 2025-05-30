using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ProductApp.Infrastructure;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString =  connectionString;
    }

    public IDbConnection CreateConnection() =>
        new SqlConnection(_connectionString);
}