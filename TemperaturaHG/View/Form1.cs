using Newtonsoft.Json;
using System.Data;
using TemperaturaHG.DataAccess;
using TemperaturaHG.Model;

namespace TemperaturaHG
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-72EIBSG\\MATTH;Initial Catalog=DataWeatherHG;User ID=sa;Password=123456;TrustServerCertificate=true";
        private DatabaseHelper databaseHelper;

        public Form1()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper(connectionString);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string strURL = "https://api.hgbrasil.com/weather?woeid=457398&array_limit=5&fields=only_results,temp,description,rain,forecast,max,min,date,time,weekday&key=694bb048";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(strURL).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Weather weatherData = JsonConvert.DeserializeObject<Weather>(result);

                    // salva os dados no banco de dados
                    databaseHelper.InsertWeatherData(weatherData);
                }
            }

            // busca os dados do banco de dados e preenche a lista WeatherDataView
            List<WeatherDataView> dataForGridView = databaseHelper.GetWeatherDataViews();

            // cria uma nova DataTable contendo os dados do forecast
            DataTable forecastTable = new DataTable();
            forecastTable.Columns.Add("Data", typeof(string));
            forecastTable.Columns.Add("Dia da semana", typeof(string));
            forecastTable.Columns.Add("MaxTemperature", typeof(int));
            forecastTable.Columns.Add("MinTemperature", typeof(int));
            forecastTable.Columns.Add("% de  chuva", typeof(double));
            forecastTable.Columns.Add("Descrição", typeof(string));

            // preenche a DataTable com os dados do forecast
            foreach (var data in dataForGridView)
            {
                foreach (var forecast in data.Forecast)
                {
                    forecastTable.Rows.Add(forecast.Date, forecast.Weekday, forecast.MaxTemperature, forecast.MinTemperature, forecast.Rain, forecast.Description);
                }
            }

            // exibe os dados no DataGridView
            dataGridView1.DataSource = forecastTable;

            // adiciona uma coluna para comparar a temperatura com o dia anterior
            var column = new DataGridViewTextBoxColumn();
            column.Name = "Diferença de Temperatura";
            column.DataPropertyName = "Diferença de Temperatura";
            column.ReadOnly = true;
            dataGridView1.Columns.Add(column);

            // preenche a coluna com a diferença de temperatura
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                int temperature = Convert.ToInt32(dataGridView1.Rows[i].Cells["MaxTemperature"].Value);
                int previousTemperature = Convert.ToInt32(dataGridView1.Rows[i - 1].Cells["MaxTemperature"].Value);
                int difference = temperature - previousTemperature;
                dataGridView1.Rows[i].Cells["Diferença de Temperatura"].Value = difference;
            }
        }
    }
}