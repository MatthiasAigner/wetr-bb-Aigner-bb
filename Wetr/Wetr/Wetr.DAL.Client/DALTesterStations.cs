
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.DAL.Dao;
using Wetr.Domainclasses;

namespace Wetr.DAL.Client
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

        public void TestFindStationById(int id)
        {
            Stations s = stationDao.FindStationById(id);
            if (s != null)
                Console.WriteLine($"FindStationById({id}) -> " +
                    $"Station: {s.Station,5} | " +
                    $"StationTyp: {s.StationTyp,-10} | " +
                    $"CoordinatesLongitude: {s.CoordinatesLongitude,5} | " +
                    $"CoordinatesLatitude: {s.CoordinatesLatitude,-10} | " +
                    $"Postalcode: {s.Postalcode,-10}");
            else
            {
                Console.WriteLine($"FindStationByName({id}) -> null"); 
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
