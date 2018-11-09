using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Domain
{
    public class Stations
    {
        public string Station { get; set; }
        public string StationTyp { get; set; }
        public string Coordinates { get; set; }
        public int Postalcode { get; set; }

        public Communities Communities { get; set; }
        public Measurements Measurements { get; set; }
        public Users Users { get; set; }
    }
}