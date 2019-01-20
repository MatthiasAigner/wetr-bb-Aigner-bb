using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Wetr.DAL.Common
{
    public delegate T RowMapper<T>(IDataRecord row);
    public delegate Task<T> RowMapperAsync<T>(IDataRecord row);
    public class AdoTemplate
    {
        private readonly IConnectionFactory connectionFactory;

        public AdoTemplate(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IEnumerable<T> Query<T>(string sql, RowMapper<T> rowMapper, SqlParameter[] parameters = null)
        {
            using (DbConnection connection = connectionFactory.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    if(parameters != null)
                    {
                        AddParameters(parameters, command);
                    }

                    var items = new List<T>();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(rowMapper(reader));
                        }
                    }
                    return items;
                }
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, RowMapper<T> rowMapper, SqlParameter[] parameters = null)
        {
            using (DbConnection connection = connectionFactory.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    if (parameters != null)
                    {
                        AddParameters(parameters, command);
                    }

                    var items = new List<T>();
                    using (DbDataReader reader =  command.ExecuteReader())
                    {
                       while (reader.Read())
                        {
                            items.Add(rowMapper(reader));
                        }
                    }
                    return items;
                }
            }
        }

        private void AddParameters(SqlParameter[] parameters, DbCommand command)
        {
            foreach(var p in parameters)
            {
                DbParameter dbParam = command.CreateParameter();
                dbParam.ParameterName = p.Name;
                dbParam.Value = p.Value;
                command.Parameters.Add(dbParam);
            }
        }

        public int Execute(string sql, SqlParameter[] parameters = null)
        {
            using (DbConnection connection = connectionFactory.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    if (parameters != null)
                    {
                        AddParameters(parameters, command);
                    }
                   
                    return command.ExecuteNonQuery();
                }
            }
        }

        public double QueryAggregate(string sql,  SqlParameter[] parameters = null)
        {
            using (DbConnection connection = connectionFactory.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    if (parameters != null)
                    {
                        AddParameters(parameters, command);
                    }

                    double items = 0.0;
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                items = reader.GetDouble(0);
                            }
                            catch(Exception)
                            {
                                return -1000.0; //if there are no values to read 
                            }
                        }
                    }
                    return items;
                }
            }
        }
    }
}
