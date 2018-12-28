using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Common;
using Wetr.Domainclasses;

namespace Wetr.DAL.Dao
{
    public class AdoStationsDao : IStationsDao
    {
        
        public static readonly RowMapper<Stations> stationMapper =
            row => new Stations { 
           
                //Id = (int) row["Id"],
                Station = (string)row["Station"],
                StationTyp = (string)row["StationTyp"],
                CoordinatesLongitude = (double)row["CoordinatesLon"],
                CoordinatesLatitude = (double)row["CoordinatesLat"],
                Postalcode = (int)row["Postalcode"]
            };        

        private readonly AdoTemplate template;

       
        public AdoStationsDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Stations> FindAllStations()
        {
        return template.Query("select * from Stations", stationMapper).ToList();
        }
        

        public Stations FindStationByName(string station)
        {
            return template.Query("select * from Stations where Station=@station",
                stationMapper,
                new[] { new SqlParameter("@station", station) }
                ).SingleOrDefault();
        }

        public Stations FindStationById(int id)
        {
            return template.Query("select * from Stations where Id=@id",
                stationMapper,
                new[] { new SqlParameter("@id", id) }
                ).SingleOrDefault();
        }

        public IEnumerable<Stations> FindStationByPostalcode(int postalcode)
        {
            return template.Query("select * from Stations where Postalcode=@postalcode",
                stationMapper,
                new[] { new SqlParameter("@postalcode", postalcode) }
                );
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
                    new SqlParameter("@postalcode", station.Postalcode)
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
