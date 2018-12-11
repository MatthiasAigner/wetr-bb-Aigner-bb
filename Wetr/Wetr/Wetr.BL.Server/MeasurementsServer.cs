using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    class MeasurementsServer : IMeasurementsServer
    {
        private IMeasurementsDao measurementsDao;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Measurements> FindAllMeasurementsInTimeInterval(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindAvgRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindAvgTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindAvgWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMaxRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMaxTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMaxWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Measurements FindMeasurementById(int id)
        {
            return measurementsDao.FindMeasurementById(id);
        }

        public double FindMinRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMinTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindMinWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public double FindSumRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool InsertMeasurement(Measurements measurement)
        {
            return measurementsDao.InsertMeasurement(measurement);
        }
    }
}
