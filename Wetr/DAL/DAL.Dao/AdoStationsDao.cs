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
    public class AdoStationsDao : IStationsDao
    {
        
        public static readonly RowMapper<Stations> stationMapper =
            row => new Stations
            {
                Station = (string)row["Station"],
                StationTyp = (string)row["StationTyp"],
                Coordinates = (string)row["Coordinates"],
                Postalcode = (int)row["Postalcode"]
            };
       

        private readonly AdoTemplate template;

        public AdoStationsDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Stations> FindAll()
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
        
        return template.Query("select * from Stations", stationMapper);
        }

        public Stations FindByName(string station)
        {
            return template.Query("select * from Stations where Station=@station",
                stationMapper,
                new[] { new SqlParameter("@station", station) }
                ).SingleOrDefault();
        }

        public bool Update(Stations station)
        {
            //return template.Execute(
            //    "update person set first_name=@fn, last_name=@ln, date_of_birth=@dob where id=@id",
            //    new[]
            //    {
            //        new SqlParameter("@id", person.Id),
            //        new SqlParameter("@fn", person.FirstName),
            //        new SqlParameter("@ln", person.LastName),
            //        new SqlParameter("@dob", person.DateOfBirth)
            //    }) == 1;
            return false;
        }
    }
}
