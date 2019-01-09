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
    public class StationsServer : IStationsServer
    {
        private static readonly IConnectionFactory connectionFactory = new DefaultConnectionFactory();        
        private IStationsDao stationsDao = new AdoStationsDao(connectionFactory);
        private ICommunitiesDao communitiesDao = new AdoCommunitiesDao(connectionFactory);
        private IDistrictDao districtsDao = new AdoDistrictDao(connectionFactory);        

        public bool DeleteStation(string station)
        {
            return stationsDao.DeleteStation(station);
        }

        public IEnumerable<Stations> FindAllStations()
        {
            return stationsDao.FindAllStations();
        }

        public IEnumerable<Stations> FindStationByDistrict(string district)
        {
            List<Stations> result = new List<Stations>();
            IEnumerable<Communities> communities = communitiesDao.FindCommunitiesByDistrict(district);
            foreach(Communities community in communities)
            {
                IEnumerable<Stations> stations = FindStationByPostalcode(community.Postalcode);
                foreach (Stations station in stations)
                {
                    result.Add(station);
                }
            }
            return result;
        }

        public Stations FindStationById(int id)
        {
            return stationsDao.FindStationById(id);
        }

        public Stations FindStationByName(string station)
        {
            return stationsDao.FindStationByName(station);
        }

        public IEnumerable<Stations> FindStationByPostalcode(int postalcode)
        {
            return stationsDao.FindStationByPostalcode(postalcode);
        }

        public IEnumerable<Stations> FindStationByProvince(string province)
        {
            List<Stations> result = new List<Stations>();
            IEnumerable<Districts> districts = districtsDao.FindDistrictsByProvince(province);
            foreach (Districts district in districts)

            {
                IEnumerable<Stations> stations = FindStationByDistrict(district.District);
                foreach (Stations station in stations)
                {
                    result.Add(station);
                }
            }
            return result;
        }

        public IEnumerable<Stations> FindStationByRegion(double lon, double lat, double radius) //radius in km; lon und lat in Grad
        {
            List<Stations> result = new List<Stations>();
            IEnumerable<Stations> allStations = stationsDao.FindAllStations();
            foreach(Stations station in allStations)
            {
                double dx = 111.3 * Math.Cos(lat) * (lon - station.CoordinatesLongitude);
                double dy = 111.3 * (lat - station.CoordinatesLatitude);
                double squareDistance = dx * dx + dy * dy;
                if (squareDistance <= radius * radius)
                {
                    result.Add(station);
                }
            }
            return result;
        }

        public bool InsertStation(Stations station)
        {
            return stationsDao.InsertStation(station);
        }
    }
}
