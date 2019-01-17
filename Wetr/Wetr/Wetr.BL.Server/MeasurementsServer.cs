using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Common;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public class MeasurementsServer : IMeasurementsServer
    {
        private static readonly IConnectionFactory connectionFactory = new DefaultConnectionFactory();
        private IMeasurementsDao measurementsDao = new AdoMeasurementsDao(connectionFactory);

        public bool DeleteMeasurement(int id)
        {
            return measurementsDao.DeleteMeasurement(id);
        }

        public IEnumerable<Measurements> FindAllMeasurements()
        {
            return measurementsDao.FindAllMeasurements();
        }

        public IEnumerable<Measurements> FindAllMeasurementsByStation(string station)
        {
            return measurementsDao.FindAllMeasurementsByStation(station);
        }

        public IEnumerable<Measurements> FindAllMeasurementsByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindAllMeasurementsByStationInTimeInterval(station, begin, end);
        }

        public IEnumerable<Measurements> FindAllMeasurementsByStationsInTimeInterval(IEnumerable<Stations> stations, DateTime begin, DateTime end)
        {
            List<Measurements> result = new List<Measurements>();
            foreach(Stations station in stations)
            {
                result.AddRange(measurementsDao.FindAllMeasurementsByStationInTimeInterval(station, begin, end));
            }
            return result;
        }

        public IEnumerable<Measurements> FindAllMeasurementsInTimeInterval(DateTime begin, DateTime end)
        {
            return measurementsDao.FindAllMeasurementsInTimeInterval(begin, end);
        }

        public double FindAvgRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindAvgRainfallByStationInTimeInterval(station, begin, end);
        }

        public double FindAvgTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindAvgTempByStationInTimeInterval(station, begin, end);
        }

        public double FindAvgWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindAvgWindspeedByStationInTimeInterval(station, begin, end);
        }

        public double FindMaxRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindMaxRainfallByStationInTimeInterval(station, begin, end);
        }

        public double FindMaxTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindMaxTempByStationInTimeInterval(station, begin, end);
        }

        public double FindMaxWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return FindMaxWindspeedByStationInTimeInterval(station, begin, end);
        }

        public Measurements FindMeasurementById(int id)
        {
            return measurementsDao.FindMeasurementById(id);
        }

        public double FindMinRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindMinRainfallByStationInTimeInterval(station, begin, end);
        }

        public double FindMinTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindMinTempByStationInTimeInterval(station, begin, end);
        }

        public double FindMinWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindMinWindspeedByStationInTimeInterval(station, begin, end);
        }

        public double FindSumRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            return measurementsDao.FindSumRainfallByStationInTimeInterval(station, begin, end);
        }

        public bool InsertMeasurement(Measurements measurement)
        {
            return measurementsDao.InsertMeasurement(measurement);
        }

        public bool InsertMeasurements(IEnumerable<Measurements> measurements)
        {
            bool successful = true;
            foreach(Measurements measurement in measurements)
            {
                successful = InsertMeasurement(measurement);
                if (!successful)
                    return false;
            }
            return true;
        }
    }
}
