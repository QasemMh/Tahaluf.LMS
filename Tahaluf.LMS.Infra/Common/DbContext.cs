using System;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Tahaluf.LMS.Core.Common;

namespace Tahaluf.LMS.Infra.Common
{
    public class DbContext : IDbContext
    {
        private DbConnection _dbConnection;
        private readonly IConfiguration _configuration;

        public DbContext(IConfiguration configuration, DbConnection dbConnection)
        {
            _configuration = configuration;
            _dbConnection = dbConnection;
        }


        public DbConnection Connection
        {
            get
            {
                if (_dbConnection == null)
                {
                    /*
                    var connectionString = _configuration.GetConnectionString("DefaultConnection");
                    var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    _dbConnection = factory.CreateConnection();
                    _dbConnection.ConnectionString = connectionString;
                     */
                    //_dbConnection = new OracleConnection(_configuration["ConnectionStrings:DefaultConnection"]);
                    _dbConnection = new OracleConnection(
                        _configuration.GetConnectionString("DefaultConnection")
                        );
                    _dbConnection.Open();
                }
                else if (_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }
                return _dbConnection;
            }
        }
    }
}
