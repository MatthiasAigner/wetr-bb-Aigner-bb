using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Domain
{
    public enum Directions
    {
        North, Northeast, East, Southeast, South, Southwest, West, Northwest
    }
    public class Measurements
    {
        public double Airtemperature { get; set; } // °C
        public double Airpressure { get; set; } // hPa
        public double Rainfall { get; set; } // mm/h
        public double Humidity { get; set; } // %
        public double WindSpeed { get; set; }// km/h
        public Directions WindDirection { get; set; }
        public DateTime Timestamp { get; set; }

        public ICollection<Stations> Stations { get; set; }
    }
}