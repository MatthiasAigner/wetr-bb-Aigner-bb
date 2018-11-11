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
    public class AdoMeasurementsDao : IMeasurementsDao
    {
        
        public static readonly RowMapper<Measurements> measurementMapper =
            row => new Measurements
            {
                Airtemperature = (double)row["Airtemperature"],
                Airpressure = (double)row["Airpressure"],
                Rainfall = (double)row["Rainfall"],
                Humidity = (double)row["Humidity"],
                WindSpeed = (double)row["WindSpeed"],
                WindDirection = (string)row["WindDirection"],
                Timestamp = (DateTime)row["Timestamp"]

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

        public Measurements FindAllMeasurementsByStation(string station)
        {
            return template.Query("select * from Measurements where Station=@station",
                measurementMapper,
                new[] { new SqlParameter("@station", station) }
                ).SingleOrDefault();
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
                "insert into Measurements values (@station, @airtemperature, @airpressure, @rainfall, @humidity, @windSpeed, @windDirection, @timestamp)",
                new[]
                {
                    new SqlParameter("@station", measurement.Station),
                    new SqlParameter("@airtemperature", measurement.Airtemperature),
                    new SqlParameter("@airpressure", measurement.Airpressure),
                    new SqlParameter("@rainfall", measurement.Rainfall),
                    new SqlParameter("@humidity", measurement.Humidity),
                    new SqlParameter("@windSpeed", measurement.WindSpeed),
                    new SqlParameter("@windDirection", measurement.WindDirection),
                    new SqlParameter("@timestamp", measurement.Timestamp),

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
    }
}
