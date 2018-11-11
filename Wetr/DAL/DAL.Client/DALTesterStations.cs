using DAL.Dao;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Client
{
    class DALTesterStations
    {
        private IStationsDao stationDao;

        public DALTesterStations(IStationsDao stationDao)
        {
            this.stationDao = stationDao;
        }

        public void TestFindAllStations()
        {
            foreach (Stations s in stationDao.FindAllStations())
            {
                Console.WriteLine($"Station: {s.Station,5} | " +
                    $"StationTyp: {s.StationTyp,-10} | " +
                    $"CoordinatesLongitude: {s.CoordinatesLongitude,5} | " +
                    $"CoordinatesLatitude: {s.CoordinatesLatitude,-10} | " +
                    $"Postalcode: {s.Postalcode,-10}");
            }
        }

        public void TestFindStationByName(string station)
        {
            Stations s = stationDao.FindStationByName(station);
            if (s != null)
                Console.WriteLine($"FindStationByName({station}) -> " +
                    $"Station: {s.Station,5} | " +
                    $"StationTyp: {s.StationTyp,-10} | " +
                    $"CoordinatesLongitude: {s.CoordinatesLongitude,5} | " +
                    $"CoordinatesLatitude: {s.CoordinatesLatitude,-10} | " +
                    $"Postalcode: {s.Postalcode,-10}");
            else
            {
                Console.WriteLine($"FindStationByName({station}) -> null");
            }
        }

        public void TestInsertStation(Stations s)
        {            
            stationDao.InsertStation(s);
            Console.WriteLine($"InsertStation({s.Station,5} | " +
                $"StationTyp: {s.StationTyp,-10} | " +
                $"CoordinatesLongitude: {s.CoordinatesLongitude,5} | " +
                $"CoordinatesLatitude: {s.CoordinatesLatitude,-10} | " +
                $"Postalcode: {s.Postalcode,-10})");
        }

        public void TestDeleteStation(string station)
        {
            stationDao.DeleteStation(station);
            Console.WriteLine($"DeleteUser({station})");
        }
    }
}
