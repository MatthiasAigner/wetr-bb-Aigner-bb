﻿using System.Collections.Generic;
using Wetr.Domainclasses;

namespace Wetr.BL.Server
{
    public interface IStationsServer
    {
        IEnumerable<Stations> FindAllStations();
        Stations FindStationByName(string station);
        Stations FindStationById(int id);
        IEnumerable<Stations> FindStationByPostalcode(int postalcode);
        IEnumerable<Stations> FindStationByRegion(double lon, double lat, double radius);
        IEnumerable<Stations> FindStationByDistrict(string district);
        IEnumerable<Stations> FindStationByProvince(string province);
        bool InsertStation(Stations station);
        bool EditStation(Stations station);
        bool DeleteStation(string station);
    }
} 
