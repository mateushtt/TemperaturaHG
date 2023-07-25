using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TemperaturaHG.DataAccess
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertWeatherData(Model.Weather weather)
        {
            string insertWeatherDataQuery = "INSERT INTO Weathers (Temp, Date, Time, Description, Rain, ForecastJson) VALUES (@Temp, @Date, @Time, @Description, @Rain, @ForecastJson)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(insertWeatherDataQuery, connection))
                {
                    command.Parameters.AddWithValue("@Temp", weather.Temp);
                    command.Parameters.AddWithValue("@Date", weather.Date);
                    command.Parameters.AddWithValue("@Time", weather.Time);
                    command.Parameters.AddWithValue("@Description", weather.Description);
                    command.Parameters.AddWithValue("@Rain", weather.Rain);
                    command.Parameters.AddWithValue("@ForecastJson", weather.ForecastJson);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Model.WeatherDataView> GetWeatherDataViews()
        {
            List<Model.WeatherDataView> dataForGridView = new List<Model.WeatherDataView>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Temp, Date, Time, Description, Rain, ForecastJson FROM Weathers";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Model.Weather> weatherDataList = new List<Model.Weather>();
                        while (reader.Read())
                        {
                            Model.Weather weatherData = new Model.Weather
                            {
                                Temp = Convert.ToInt32(reader["Temp"]),
                                Date = reader["Date"].ToString(),
                                Time = reader["Time"].ToString(),
                                Description = reader["Description"].ToString(),
                                Rain = Convert.ToDouble(reader["Rain"]),
                                Forecast = JsonConvert.DeserializeObject<List<Model.Forecast>>(reader["ForecastJson"].ToString())
                            };

                            weatherDataList.Add(weatherData);
                        }

                        // com a lista de WeatherData, calcular a propriedade TemperatureIncreased
                        for (int i = 0; i < weatherDataList.Count; i++)
                        {
                            Model.Weather currentData = weatherDataList[i];
                            Model.Weather previousData = i > 0 ? weatherDataList[i - 1] : null;

                            bool increased = previousData != null && currentData.Temp > previousData.Temp;

                            Model.WeatherDataView currentDataView = new Model.WeatherDataView
                            {
                                Temp = currentData.Temp,
                                Date = currentData.Date,
                                Time = currentData.Time,
                                Description = currentData.Description,
                                Rain = currentData.Rain,
                                TemperatureIncreased = increased,
                                Forecast = currentData.Forecast // exibe apenas os dados do forecast no DataGridView
                            };

                            dataForGridView.Add(currentDataView);
                        }
                    }
                }
            }

            return dataForGridView;
        }
    }
}