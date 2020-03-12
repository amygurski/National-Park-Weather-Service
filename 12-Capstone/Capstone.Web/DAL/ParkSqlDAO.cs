using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private readonly string connectionString;
        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get list of all Parks with all of their details from the SQL database
        /// </summary>
        public IList<Park> GetParks()
        {
            List<Park> output = new List<Park>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "SELECT * FROM park order by parkName";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Park park = RowToObject(reader);
                        output.Add(park);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return output;
        }
        
        /// <summary>
        /// Get the park with all it's details for the specified id
        /// </summary>
        public Park GetPark(string parkCode)
        {
            Park park = null;
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //Open the connection
                    conn.Open();

                    string sql = "select * from park where parkCode = @parkCode";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    //Prevent SQL Injection
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    //Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    //Loop through each row
                    while (reader.Read())
                    {
                        park = RowToObject(reader);
                    }
                }
            }
            catch
            {
                throw;
            }
            return park;
        }

        /// <summary>
        /// Get a List of SelectListItems containing the Park Name for the text 
        /// and the park code for the value for the survey
        /// </summary>
        public List<SelectListItem> GetParkNames()
        {
            List<SelectListItem> output = new List<SelectListItem>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "SELECT * FROM park order by parkName";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Text = Convert.ToString(reader["parkName"]);
                        item.Value = Convert.ToString(reader["parkCode"]);
                        output.Add(item);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return output;
        }

        /// <summary>
        /// Convert each row in the SQL database to a Park
        /// </summary>
        private Park RowToObject(SqlDataReader reader)
        {
            Park park = new Park()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
            return park;
        }
    }
}
