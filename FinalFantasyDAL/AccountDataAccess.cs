using FinalFantasyDAL.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FinalFantasyDAL
{
    public class AccountDataAccess
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["capstoneConnection"].ConnectionString;

        public UserDO ViewUserByUsername(string userName)
        {
            UserDO response = new UserDO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_USER_BY_USERNAME", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@userName", userName);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    response.UserID = reader.GetInt64(0);
                    response.FullName = reader.GetString(1);
                    response.UserName = reader.GetString(2);
                    response.UserPassword = reader.GetString(3);
                    response.RoleID = reader.GetInt64(4);
                    response.Email = reader.GetString(5);
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch(Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "ViewUserByUsername", "DAL", "Error");
            }
            return response;
        }    
    }
}
