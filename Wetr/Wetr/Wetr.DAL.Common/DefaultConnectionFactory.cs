using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetr.DAL.Common
{

    public class DefaultConnectionFactory : IConnectionFactory
    {

        private DbProviderFactory dbProviderFactory;

        public static IConnectionFactory FromConfiguration(string connectionStringConfigName)
        {
            string connectionString = ConfigurationManager
                                       .ConnectionStrings[connectionStringConfigName]
                                       .ConnectionString;

            string providerName = ConfigurationManager
                                   .ConnectionStrings[connectionStringConfigName]
                                   .ProviderName;

            return new DefaultConnectionFactory(providerName, connectionString);
        }

        public DefaultConnectionFactory(string providerName = "System.Data.SqlClient", string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aigne\\source\\repos\\Db\\Wetr_db.mdf;Integrated Security=True;Connect Timeout=30")
        {
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
            this.dbProviderFactory = DbProviderFactories.GetFactory(providerName);
        }

        public string ConnectionString { get; }

        public string ProviderName { get; }

        public DbConnection CreateConnection()
        {
            var connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = this.ConnectionString;
            connection.Open();
            return connection;
        }

        public async Task<DbConnection> CreateConnectionAsync()
        {
            var connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = this.ConnectionString;
            await connection.OpenAsync();
            return connection;
        }
    }
}
