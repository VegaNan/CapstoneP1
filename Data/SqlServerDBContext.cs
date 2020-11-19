using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace VegaN_Capstone.Data
{
    public class SqlServerDBContext
    {
        private readonly SqlServerSettings sqlServerSettings;

        public SqlServerDBContext(IOptions<SqlServerSettings> configuration)
        {
            sqlServerSettings = configuration.Value;
        }


        public DbConnection connection()
        {
            var connectionString = new SqlConnectionStringBuilder()
            {

                DataSource = sqlServerSettings.Server,     // e.g. '127.0.0.1' 
                UserID = sqlServerSettings.UserId,        // e.g. 'my-db-user'
                Password = sqlServerSettings.Password,       // e.g. 'my-db-password'
                InitialCatalog = sqlServerSettings.Database, // e.g. 'my-database'
                Encrypt = false,
            };
            connectionString.Pooling = true;      
            connectionString.MaxPoolSize = 5;
            connectionString.MinPoolSize = 0;
            connectionString.ConnectTimeout = 15;
            DbConnection connection =
                new SqlConnection(connectionString.ConnectionString);
            return connection;

        }
    }
}
