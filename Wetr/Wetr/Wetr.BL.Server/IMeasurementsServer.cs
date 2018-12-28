
using System;
using System.Collections.Generic;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface IMeasurementsServer
    {
        IEnumerable<Measurements> FindAllMeasurements();
        IEnumerable<Measurements> FindAllMeasurementsByStation(string station);
        Measurements FindMeasurementById(int id);
        IEnumerable<Measurements> FindAllMeasurementsByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        IEnumerable<Measurements> FindAllMeasurementsInTimeInterval(DateTime begin, DateTime end);
        double FindMaxTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMaxRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindSumRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMaxWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        bool InsertMeasurement(Measurements measurement);
        bool DeleteMeasurement(int id);
    }
}
