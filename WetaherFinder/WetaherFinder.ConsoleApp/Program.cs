using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WetaherFinder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var forecasts = GetWeatherForecastData();

            using (var dbContext = new FakeDb())
            {
                for (int i = 0; i < forecasts.Count; i++)
                {
                    dbContext.Forecasts.Add(forecasts[i]);
                }
                dbContext.SaveChanges();
            }

            using (var dbContext = new FakeDb())
            {
                var ndbForecast =  dbContext.Forecasts.AsNoTracking().ToList();
                for (int i = 0; i < ndbForecast.Count; i++)
                {
                    Console.WriteLine(
                        $"{ndbForecast[i].Id,-20}|" +
                        $"{ndbForecast[i].Date.ToLongDateString(),-30}| " +
                        $"{ndbForecast[i].TemperatureC,-12:N2}| " +
                        $"{ndbForecast[i].Summary,-20}|" +
                        $"{ndbForecast[i].City,-20}|"
                    );
                }
                Console.WriteLine("Total: " + ndbForecast.Count);
            }

            //Console.WriteLine("----------------------------------------------------------------------------------------");
            //Console.WriteLine($"{"WEATHER-FINDER",50}");
            //Console.WriteLine("----------------------------------------------------------------------------------------");
            //Console.WriteLine($"{"Date",-30}| {"Temperature "}| {"Summary",-20}|\n");
            //Console.WriteLine("----------------------------------------------------------------------------------------");
            //for (int i = 0; i < forecasts.Count; i++)
            //{
            //    Console.WriteLine(
            //        $"{forecasts[i].Date.ToLongDateString(),-30}| " +
            //        $"{forecasts[i].TemperatureC,-12:N2}| " +
            //        $"{forecasts[i].Summary,-20}|"
            //    );
            //}
            //Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        private static List<WeatherForecast> GetWeatherForecastData()
        {
            var weeklyForecast = new List<WeatherForecast>();
            var rng = new Random();
            string[] Summaries =
                new[]

                {

                    "Freezing",

                    "Bracing",

                    "Chilly",

                    "Cool",

                    "Mild",

                    "Warm",

                    "Balmy",

                    "Hot",

                    "Sweltering",

                    "Scorching"

                };

            string[] Cities =
              new[]

              {

                    "Aksokovo",

                    "Plovdiv",

                    "Buenos Aires",

                    "Tokyo"
              };

            for (int i = 0; i < 7; i++)
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var newId =  
                    new string(
                        Enumerable.Repeat(chars, rng.Next(10, 32)
                    )
                    .Select(s => s[rng.Next(s.Length)]).ToArray()
                  );

                var forecast = new WeatherForecast
                {
                    Id = newId,
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    //Humidity = RandomGeneratorUtils.NextDouble(rng, 0, 100),
                    //Pressure = RandomGeneratorUtils.NextDouble(rng, 0, 100),
                    Summary = Summaries[rng.Next(Summaries.Length)],
                    City = Cities[rng.Next(Cities.Length)]
                };
                weeklyForecast.Add(forecast);
            };
            return weeklyForecast;
        }
    }
}
