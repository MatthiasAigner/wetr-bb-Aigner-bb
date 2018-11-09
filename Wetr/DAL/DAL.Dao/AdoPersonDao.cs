using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Common;
using DAL.Domain;

namespace DAL.Dao
{
    public class AdoPersonDao : IPersonDao
    {
        public static readonly RowMapper<Person> personMapper =
            row => new Person
            {
                Id = (int)row["id"],
                FirstName = (string)row["first_name"],
                LastName = (string)row["last_name"],
                DateOfBirth = (DateTime)row["date_of_birth"]
            };

        private readonly AdoTemplate template;

        public AdoPersonDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Person> FindAll()
        {
        //    string connString = ConfigurationManager.ConnectionStrings["PersonDbConnection"].ConnectionString;
        //    string providerName = ConfigurationManager.ConnectionStrings["PersonDbConnection"].ProviderName;

        //    DbProviderFactory dbFactory = DbProviderFactories.GetFactory(providerName);

        //    using (DbConnection connection = dbFactory.CreateConnection())
        //    {
        //        connection.ConnectionString = connString;
        //        connection.Open();

        //        using (DbCommand command = connection.CreateCommand())
        //        {
        //            command.CommandText = "select * from person";

        //            var items = new List<Person>();
        //            using (DbDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    items.Add(
        //                        new Person
        //                        {
        //                            Id = (int)reader["id"],
        //                            FirstName = (string)reader["first_name"],
        //                            LastName = (string)reader["last_name"],
        //                            DateOfBirth = (DateTime)reader["date_of_birth"]
        //                        }
        //                     );
        //                }
        //            }
        //            return items;
        //        }                
        //    }
        
        return template.Query("select * from person", personMapper);
        }

        public Person FindById(int id)
        {
            return template.Query("select * from person where id=@id",
                personMapper,
                new[] { new SqlParameter("@id", id) }
                ).SingleOrDefault();
        }

        public bool Update(Person person)
        {
            return template.Execute(
                "update person set first_name=@fn, last_name=@ln, date_of_birth=@dob where id=@id",
                new[]
                {
                    new SqlParameter("@id", person.Id),
                    new SqlParameter("@fn", person.FirstName),
                    new SqlParameter("@ln", person.LastName),
                    new SqlParameter("@dob", person.DateOfBirth)
                }) == 1;
        }
    }
}
