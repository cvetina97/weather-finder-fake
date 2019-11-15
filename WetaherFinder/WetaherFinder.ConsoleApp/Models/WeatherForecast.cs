using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WetaherFinder.ConsoleApp
{
    public class WeatherForecast
    {
        public WeatherForecast() {  }

        public string Id { get; set; }
        public DateTime Date { get; set; }

        public string Summary { get; set; }

        public double TemperatureC { get; set; }

        public double Humidity { get; set; }

        public double Pressure { get; set; }
        public string City { get; set; }
    }
}
