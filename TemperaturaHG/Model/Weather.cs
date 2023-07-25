using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperaturaHG.Model
{
    public class Weather
    {
        public int Id { get; set; }
        public int Temp { get; set; } = 0;
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public string Description { get; set; } = "";
        public double Rain { get; set; } = 0.0;
        [NotMapped] // indica que essa propriedade não será mapeada para o banco de dados
        public List<Forecast> Forecast { get; set; } = new List<Forecast>();
        public string ForecastJson // propriedade para armazenar o JSON da lista de previsões
        {
            get => JsonConvert.SerializeObject(Forecast);
            set => Forecast = JsonConvert.DeserializeObject<List<Forecast>>(value);
        }
    }

    public class Forecast
    {
        [JsonProperty("date")]
        public string Date { get; set; } = "";

        [JsonProperty("weekday")]
        public string Weekday { get; set; } = "";

        [JsonProperty("max")]
        public int MaxTemperature { get; set; }

        [JsonProperty("min")]
        public int MinTemperature { get; set; }

        [JsonProperty("rain")]
        public double Rain { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = "";
    }
}