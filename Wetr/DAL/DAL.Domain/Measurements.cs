using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Domain
{
    
    public class Measurements
    {
        public Measurements()
        {
        }

        public Measurements(string station, double airtemperature, double airpressure, double rainfall, double humidity, double windSpeed, string windDirection, DateTime timestamp)
        {
            this.Station = station;
            this.Airtemperature = airtemperature;
            this.Airpressure = airpressure;
            this.Rainfall = rainfall;
            this.Humidity = humidity;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.Timestamp = timestamp;
        }

        public string Station { get; set; }
        public double Airtemperature { get; set; } // °C
        public double Airpressure { get; set; } // hPa
        public double Rainfall { get; set; } // mm/h
        public double Humidity { get; set; } // %
        public double WindSpeed { get; set; }// km/h
        public string WindDirection { get; set; }
        public DateTime Timestamp { get; set; }
        
    }
}