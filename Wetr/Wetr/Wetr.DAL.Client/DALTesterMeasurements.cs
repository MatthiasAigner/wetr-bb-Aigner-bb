
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.DAL.Client
{
    class DALTesterMeasurements
    {
        private IMeasurementsDao measurementDao;

        public DALTesterMeasurements(IMeasurementsDao measurementDao)
        {
            this.measurementDao = measurementDao;
        }

        public void TestFindAllMeasurements()
        {
            foreach (Measurements m in measurementDao.FindAllMeasurements())
            {
                Console.WriteLine($"Station: {m.Station,5} | " +
                    $"Airtemperature: {m.Airtemperature,-10} | " +
                    $"Airpressure: {m.Airpressure,5} | " +
                    $"Rainfall: {m.Rainfall,-10} | " +
                    $"Humidity: {m.Humidity,-10} | " +
                    $"WindSpeed: {m.WindSpeed,5} | " +
                    $"WindDirection: {m.WindDirection,-10} | " +
                    $"Timestamp: {m.Timestamp,-10}");
            }
        }

        public void TestFindAllMeasurementsByStation(string station)
        {
            Measurements m = measurementDao.FindAllMeasurementsByStation(station);
            if (m != null)
                Console.WriteLine($"FindAllMeasurementsByStation({station}) -> " +
                    $"Station: {m.Station,5} | " +
                    $"Airtemperature: {m.Airtemperature,-10} | " +
                    $"Airpressure: {m.Airpressure,5} | " +
                    $"Rainfall: {m.Rainfall,-10} | " +
                    $"Humidity: {m.Humidity,-10} | " +
                    $"WindSpeed: {m.WindSpeed,5} | " +
                    $"WindDirection: {m.WindDirection,-10} | " +
                    $"Timestamp: {m.Timestamp,-10}");
            else
            {
                Console.WriteLine($"FindAllMeasurementsByStation({station}) -> null");
            }
        }

        public void TestFindMeasurementById(int id)
        {
            Measurements m = measurementDao.FindMeasurementById(id);
            if (m != null)
                Console.WriteLine($"FindMeasurementById({id}) -> Station: {m.Station,5} " +
                    $"| Airtemperature: {m.Airtemperature,-10} | " +
                    $"Airpressure: {m.Airpressure,5} | " +
                    $"Rainfall: {m.Rainfall,-10} | " +
                    $"Humidity: {m.Humidity,-10} | " +
                    $"WindSpeed: {m.WindSpeed,5} | " +
                    $"WindDirection: {m.WindDirection,-10} | " +
                    $"Timestamp: {m.Timestamp,-10}");
            else 
            {
                Console.WriteLine($"FindAllMeasurementsById({id}) -> null");
            }
        }

        public void TestInsertMeasurement(Measurements m)
        {
            measurementDao.InsertMeasurement(m);
            Console.WriteLine($"InsertMeasurement({m.Station,5} | " +
                $"Airtemperature: {m.Airtemperature,-10} | " +
                $"Airpressure: {m.Airpressure,5} | " +
                $"Rainfall: {m.Rainfall,-10} | " +
                $"Humidity: {m.Humidity,-10} | " +
                $"WindSpeed: {m.WindSpeed,5} | " +
                $"WindDirection: {m.WindDirection,-10} | " +
                $"Timestamp: {m.Timestamp,-10})");
        }

        public void TestDeleteMeasurement(int id)
        {
            measurementDao.DeleteMeasurement(id);
            Console.WriteLine($"DeleteUser({id})");
        }
    }









}
