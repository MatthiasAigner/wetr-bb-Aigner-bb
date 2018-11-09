using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public interface IConnectionFactory
    {
        string ConnectionString { get; }
        string ProviderName { get; }
        DbConnection CreateConnection();

        Task<DbConnection> CreateConnectionAsync();

    }
}
