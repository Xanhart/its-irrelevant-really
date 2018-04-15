using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ScavengerHunt.Models;

namespace ScavengerHunt.DAL
{
    public class ParkDAL : IParkDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private const string SQL_GetAllParks = "SELECT * from parks";


        public List<Park> AllParks()
        {
            List<Park> allParks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park p = new Park();
                        p.ParkID = Convert.ToInt32(reader["id"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);                        
                        p.Parkaddress = Convert.ToString(reader["parkAddress"]);
                        p.ParkCity = Convert.ToString(reader["parkCity"]);
                        p.ParkState = Convert.ToString(reader["parkState"]);
                        p.ParkZip = Convert.ToInt32(reader["parkZip"]);                        

                        allParks.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return allParks;
        }
    }
}
