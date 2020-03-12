using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyResultsSqlDAO : ISurveyResultsDAO
    {
        private readonly string connectionString;
        public SurveyResultsSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the survey to the Database
        /// </summary>
        public bool SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //Open connection
                    conn.Open();

                    string sql = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    //Prevent SQL Injection
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.ResidenceState);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    //Execute the SQL command
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get survey results from database
        /// Returns count of votes by park name
        /// If the votes are tied, it sorts the parks alphabetically
        /// </summary>
        public IList<SurveyResultVM> GetSurveyResults()
        {
            IList<SurveyResultVM> results = new List<SurveyResultVM>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //Open connection
                    conn.Open();

                    string sql =
                        @"select survey_result.parkCode, parkName, count(survey_result.parkCode) AS votes
                        from survey_result
                        join park on park.parkCode = survey_result.parkCode
                        group by survey_result.parkCode, parkName
                        order by votes desc, parkName asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //Loop through each row
                    //All we want are the parkCode (for the image), the parkName and the number of votes per park
                    //Add them to the list of survey results
                    while (reader.Read())
                    {
                        SurveyResultVM resultVM = new SurveyResultVM();
                        resultVM.ParkCode = Convert.ToString(reader["parkCode"]);
                        resultVM.ParkName = Convert.ToString(reader["parkName"]);
                        resultVM.Votes = Convert.ToInt32(reader["votes"]);
                        results.Add(resultVM);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return results;
        }
    }
}
