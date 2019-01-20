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

        public Task<IEnumerable<Measurements>> FindAllMeasurementsByStationInTimeIntervalAsync(Stations station, DateTime begin, DateTime end)
        {
            // List<Measurements> res = new List<Measurements>();
            var res = template.QueryAsync("select * from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                measurementMapper,
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return res;
        }

        public IEnumerable<Measurements> FindAllMeasurementsInTimeInterval(DateTime begin, DateTime end)
        {
            return template.Query("select * from Measurements where Timestamp>=@begin and Timestamp<=@end",
                measurementMapper,
                new[]
                {
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
        }

        public double FindMaxTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MAX(Airtemperature) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMinTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MIN(Airtemperature) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindAvgTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select AVG(Airtemperature) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMaxRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MAX(Rainfall) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMinRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MIN(Rainfall) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindAvgRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select AVG(Rainfall) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindSumRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select SUM(Rainfall) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMaxWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MAX(Windspeed) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMinWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MIN(Windspeed) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindAvgWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select AVG(Windspeed) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public IEnumerable<Measurements> FindAllMeasurementsByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return template.Query("select * from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                measurementMapper,
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
        }

        public double FindMaxPressureByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MAX(Airpressure) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMinPressureByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MIN(Airpressure) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindAvgPressureByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select AVG(Airpressure) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMaxHumidityByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select Max(Humidity) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindMinHumidityByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select MIN(Humidity) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }

        public double FindAvgHumidityByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            var result = template.QueryAggregate("select AVG(Humidity) from Measurements where Station=@station and Timestamp>=@begin and Timestamp<=@end",
                new[]
                {
                    new SqlParameter("@station", station.Station),
                    new SqlParameter("@begin", begin),
                    new SqlParameter("@end", end)
                });
            return Convert.ToDouble(result);
        }
    }
}