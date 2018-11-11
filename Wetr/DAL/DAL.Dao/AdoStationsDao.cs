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
                CoordinatesLongitude = (double)row["CoordinatesLongitude"],
                CoordinatesLatitude = (double)row["CoordinatesLatitude"],
                Postalcode = (int)row["Postalcode"]
            };
       

        private readonly AdoTemplate template;

        public AdoStationsDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Stations> FindAllStations()
        {
        return template.Query("select * from Stations", stationMapper);
        }

        public Stations FindStationByName(string station)
        {
            return template.Query("select * from Stations where Station=@station",
                stationMapper,
                new[] { new SqlParameter("@station", station) }
                ).SingleOrDefault();
        }

        public bool InsertStation(Stations station)
        {
            return template.Execute(
                "insert into Stations values (@station, @stationTyp, @coordinatesLongitude, @coordinatesLatitude, @postalcode)",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@stationTyp", station.StationTyp),
                    new SqlParameter("@coordinatesLongitude", station.CoordinatesLongitude),
                    new SqlParameter("@coordinatesLatitude", station.CoordinatesLatitude),
                    new SqlParameter("@postalcode", station.Postalcode),

                }) == 1;
        }

        public bool DeleteStation(string station)
        {
            return template.Execute(
                "delete from Stations where Station=@station",
                new[]
                {
                    new SqlParameter("@station", station)
                }) == 1;
        }
    }
}
