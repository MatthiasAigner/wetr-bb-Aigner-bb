
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface IMeasurementsServer
    {
        IEnumerable<Measurements> FindAllMeasurements();
        IEnumerable<Measurements> FindAllMeasurementsByStation(string station);
        Measurements FindMeasurementById(int id);
        IEnumerable<Measurements> FindAllMeasurementsByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        IEnumerable<Measurements> FindAllMeasurementsByStationsInTimeInterval(IEnumerable<Stations> stations, DateTime begin, DateTime end);
        IEnumerable<Measurements> FindAllMeasurementsInTimeInterval(DateTime begin, DateTime end);
        double FindMaxTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgTempByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMaxPressureByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinPressureByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgPressureByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMaxRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindSumRainfallByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMaxHumidityByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinHumidityByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgHumidityByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMaxWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindMinWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        double FindAvgWindspeedByStationInTimeInterval(Stations station, DateTime begin, DateTime end);
        bool InsertMeasurement(Measurements measurement);
        bool InsertMeasurements(IEnumerable<Measurements> measurements);
        bool DeleteMeasurement(int id);
        Task<IEnumerable<Measurements>> FindAllMeasurementsByStationsInTimeIntervalAsync(IEnumerable<Stations> stations, DateTime begin, DateTime end);
    }
}
