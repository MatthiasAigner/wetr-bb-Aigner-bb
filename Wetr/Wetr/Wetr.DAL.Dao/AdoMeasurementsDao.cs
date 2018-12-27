using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Common;
using Wetr.Domainclasses;

namespace Wetr.DAL.Dao
{
    public class AdoMeasurementsDao : IMeasurementsDao
    {

        public static readonly RowMapper<Measurements> measurementMapper =
            row => new Measurements
            {
                //Id = (int)row["Id"],
                Station = (string)row["Station"],
                Timestamp = (DateTime)row["Timestamp"],
                Airtemperature = (double)row["Airtemperature"],
                Airpressure = (double)row["Airpressure"],
                Rainfall = (double)row["Rainfall"],
                Humidity = (double)row["Humidity"],
                WindSpeed = (double)row["WindSpeed"],
                WindDirection = (string)row["WindDirection"]     
            };         

        private readonly AdoTemplate template;

        public AdoMeasurementsDao(IConnectionFactory connectionFactory)
        {
            this.template = new AdoTemplate(connectionFactory);
        }

        public IEnumerable<Measurements> FindAllMeasurements()
        {
            return template.Query("select * from Measurements", measurementMapper);
        }

        public IEnumerable<Measurements> FindAllMeasurementsByStation(string station)
        {
            return template.Query("select * from Measurements where Station=@station",
                measurementMapper,
                new[] { new SqlParameter("@station", station) }
                );
        }

        public Measurements FindMeasurementById(int id)
        {
            return template.Query("select * from Measurements where id=@id",
                measurementMapper,
                new[] { new SqlParameter("@id", id) }
                ).SingleOrDefault();
        }

        public bool InsertMeasurement(Measurements measurement)
        {
            return template.Execute(
                "insert into Measurements values ( @station, @timestamp, @airtemperature, @airpressure, @rainfall, @humidity, @windSpeed, @windDirection)",
                new[]
                {  
                    new SqlParameter("@station", measurement.Station),
                    new SqlParameter("@timestamp", measurement.Timestamp),
                    new SqlParameter("@airtemperature", measurement.Airtemperature),
                    new SqlParameter("@airpressure", measurement.Airpressure),
                    new SqlParameter("@rainfall", measurement.Rainfall),
                    new SqlParameter("@humidity", measurement.Humidity),
                    new SqlParameter("@windSpeed", measurement.WindSpeed),
                    new SqlParameter("@windDirection", measurement.WindDirection)
                }) == 1;
        }

        public bool DeleteMeasurement(int id)
        {
            return template.Execute(
                "delete from Measurements where Id=@id",
                new[]
                {
                    new SqlParameter("@id", id)
                }) == 1;
        }

        

        public IEnumerable<Measurements> FindAllMeasurementsByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return template.Query("select * from Measurements where Station=@station, Timestamp>=@begin, Timestamp<=@end",
                measurementMapper,
                new[]
                {
                    new SqlParameter("@station", station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
        }

        public IEnumerable<Measurements> FindAllMeasurementsInTimeInterval(DateTime begin, DateTime end)
        {
            return template.Query("select * from Measurements where Timestamp>=@begin, Timestamp<=@end",
                measurementMapper,
                new[]
                {
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
        }

        public double FindMaxTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.Query("select MAX(Temperatures) from Measurements where Station=@station, Timestamp>=@begin, Timestamp<=@end",
                measurementMapper,
                new[]
                {
                    new SqlParameter("@station", station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                }).SingleOrDefault();
            return Convert.ToDouble(result);
            
        }

        public double FindMinTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindAvgTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMaxRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMinRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindAvgRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindSumRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMaxWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMinWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindAvgWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
