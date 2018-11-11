using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Domain
{
    public class Stations
    {
        public Stations()
        {
        }

        public Stations(string station, string stationTyp, double coordinatesLongitude, double coordinatesLatitude, int postalcode)
        {
            this.Station = station;
            this.StationTyp = stationTyp;
            this.CoordinatesLongitude = coordinatesLongitude;
            this.CoordinatesLatitude = coordinatesLatitude;
            this.Postalcode = postalcode;
        }

        public string Station { get; set; }
        public string StationTyp { get; set; }
        public double CoordinatesLongitude { get; set; }
        public double CoordinatesLatitude { get; set; }
        public int Postalcode { get; set; }

        
    }
}