﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetr.Domainclasses;

namespace Wetr.DAL.Dao
{
    public interface IStationsDao
    {
        IEnumerable<Stations> FindAllStations();
        Stations FindStationByName(string station);
        Stations FindStationById(int id);
        IEnumerable<Stations> FindStationByPostalcode(int postalcode);
        bool InsertStation(Stations station);
        bool EditStation(Stations station);
        bool DeleteStation(string station);
    }
} 
