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
    public class AdoDao : IDao
    {
        public static readonly RowMapper<Person> personMapper =
            row => new Person
            {
                Id = (int)row["id"],
                FirstName = (string)row["first_name"],
                LastName = (string)row["last_name"],
                DateOfBirth = (DateTime)row["date_of_birth"]
            };
        public static readonly RowMapper<Communities> communitiesMapper =
            row => new Communities
            {
                Community = (string)row["Community"],
                Postalcode = (int)row["Postalcode"],
                District = (string)row["District"],
                Procince = (string)row["Procince"]
            };
        public static readonly RowMapper<Measurements> measurementsMapper =
            row => new Measurements
            {
                Airtemperature = (int)row["Airtemperature"],
                Airpressure = (double)row["Airpressure"],
                Rainfall = (double)row["Rainfall"],
                Humidity = (double)row["Humidity"],
                WindSpeed = (double)row["WindSpeed"],
                WindDirection = (string)row["WindDirection"],
                Timestamp = (DateTime)row["Timestamp"]

            };
        public static readonly RowMapper<Stations> stationMapper =
            row => new Stations
            {
                Station = (string)row["Station"],
                StationTyp = (string)row["StationTyp"],
                Coordinates = (string)row["Coordinates"],
                Postalcode = (int)row["Postalcode"]
            };
        public static readonly RowMapper<Users> userMapper =
            row => new Users
            {
                Username = (string)row["Username"],
                Station = (string)row["Station"]
            };

        private readonly AdoTemplate template;

        public AdoDao(IConnectionFactory connectionFactory)
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
