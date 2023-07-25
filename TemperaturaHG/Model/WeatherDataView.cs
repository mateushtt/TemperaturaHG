using Newtonsoft.Json;
using System.Collections.Generic;

namespace TemperaturaHG.Model
{
    public class WeatherDataView
    {
        public int Temp { get; set; }
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public string Description { get; set; } = "";
        public double Rain { get; set; }
        public bool TemperatureIncreased { get; set; }
        public List<Forecast> Forecast { get; set; } = new List<Forecast>();
    }
}