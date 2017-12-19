using System;
using System.Collections.Generic;
using System.Configuration;
using FinalFantasyDAL.Models;
using System.Data.SqlClient;
using System.Data;

namespace FinalFantasyDAL
{
    public class UserDL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["capstoneConnection"].ConnectionString;

        public List<UserDO> ViewUsers()
        {
            List<UserDO> userList = new List<UserDO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_USERS", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UserDO userObject = new UserDO();
                        userObject.UserID = reader.GetInt64(0);
                        userObject.FullName = reader.GetString(1);
                        userObject.UserName = reader.GetString(2);
                        userObject.UserPassword = reader.GetString(3);
                        userObject.RoleID = reader.GetInt64(4);
                        userObject.Email = reader.GetString(5);
                        userList.Add(userObject);
                    }
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "ViewUsers", "DAL", "Error");
            }
            return userList;
        }
        public void CreateUser(UserDO userObject)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("CREATE_USER", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@fullName", userObject.FullName);
                    command.Parameters.AddWithValue("@userName", userObject.UserName);
                    command.Parameters.AddWithValue("@userPassword", userObject.UserPassword);
                    command.Parameters.AddWithValue("@roleID", userObject.RoleID);
                    command.Parameters.AddWithValue("@email", userObject.Email);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorLog error = new ErrorLog();
                error.Log(sqlEx, "CreateUser", "SQL", "Error");
                throw sqlEx;
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "CreateUser", "DAL", "Error");
            }
        }
        public void UpdateUser(UserDO userObject)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE_USER", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@userID", userObject.UserID);
                    command.Parameters.AddWithValue("@fullName", userObject.FullName);
                    command.Parameters.AddWithValue("@userName", userObject.UserName);
                    command.Parameters.AddWithValue("@userPassword", userObject.UserPassword);
                    command.Parameters.AddWithValue("@roleID", userObject.RoleID);
                    command.Parameters.AddWithValue("@email", userObject.Email);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorLog error = new ErrorLog();
                error.Log(sqlEx, "UpdateUser", "SQL", "Error");
                throw sqlEx;
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "UpdateUser", "DAL", "Error");
            }
        }
        public void DeleteUser(Int64 userID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE_USER", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@userID", userID);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "DeleteUser", "DAL", "Error");
            }
        }
        public UserDO GetUserByID(int UserID)
        {
            UserDO user = new UserDO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_USER_BY_ID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@userID", UserID);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    user.UserID = reader.GetInt64(0);
                    user.FullName = reader.GetString(1);
                    user.UserName = reader.GetString(2);
                    user.UserPassword = reader.GetString(3);
                    user.RoleID = reader.GetInt64(4);
                    user.Email = reader.GetString(5);
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "GetUserByID", "DAL", "Error");
            }
            return user;
        }
    }
}
