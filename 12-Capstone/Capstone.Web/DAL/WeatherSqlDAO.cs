using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private readonly string connectionString;
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get the weather for the specified park
        /// </summary>
        public IList<WeatherForecast> GetFiveDayWeatherForecast(string parkCode)
        {
            List<WeatherForecast> output = new List<WeatherForecast>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from weather where parkCode = @parkCode";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //Read each of the 5 days weather and add them to the weather forecast list
                    while (reader.Read())
                    {
                        WeatherForecast weather = RowToObject(reader);
                        output.Add(weather);
                    }
                }
            }
            catch
            {
                throw;
            }
            return output;
        }

        /// <summary>
        /// Turn a SQL database row into a WeatherForecast
        /// </summary>
        private WeatherForecast RowToObject(SqlDataReader reader)
        {
            WeatherForecast weather = new WeatherForecast()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                Low = Convert.ToInt32(reader["low"]),
                High= Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
            return weather;
        }
    }
}
