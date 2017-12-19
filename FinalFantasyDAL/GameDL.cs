using FinalFantasyDAL.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;

namespace FinalFantasyDAL
{
    public class GameDL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["capstoneConnection"].ConnectionString;

        public List<GameDO> ViewGames()
        {
            List<GameDO> gameList = new List<GameDO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_GAMES", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GameDO gameObject = new GameDO();


                        gameObject.GameID = reader.GetInt64(0);
                        gameObject.GameTitle = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                        {
                            gameObject.RomanNumeral = reader.GetString(2);
                        }
                        else
                        {

                        }
                        gameObject.ReleaseDate = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                        {
                            gameObject.CopiesSold = reader.GetInt32(4);
                        }
                        else
                        {

                        }
                        gameObject.GameSummary = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                        {
                            gameObject.Price = reader.GetDecimal(6);
                        }
                        else
                        {

                        }
                        gameList.Add(gameObject);
                    }
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }

            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "ViewGames", "DAL", "Error");
            }
            return gameList;
        }
        public void CreateGame(GameDO gameObject)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("CREATE_GAME", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@gameTitle", gameObject.GameTitle);
                    command.Parameters.AddWithValue("@romanNumeral", gameObject.RomanNumeral);
                    command.Parameters.AddWithValue("@releaseDate", gameObject.ReleaseDate);
                    command.Parameters.AddWithValue("@copiesSold", gameObject.CopiesSold);
                    command.Parameters.AddWithValue("@gameSummary", gameObject.GameSummary);
                    command.Parameters.AddWithValue("@price", gameObject.Price);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "CreateGame", "DAL", "Error");
            }
        }
        public void DeleteGame(Int64 gameID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE_GAME", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@gameID", gameID);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "DeleteGame", "DAL", "Error");
            }
        }
        public void UpdateGame(GameDO gameObject)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE_GAME", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@gameID", gameObject.GameID);
                    command.Parameters.AddWithValue("@gameTitle", gameObject.GameTitle);
                    command.Parameters.AddWithValue("@romanNumeral", gameObject.RomanNumeral);
                    command.Parameters.AddWithValue("@releaseDate", gameObject.ReleaseDate);
                    command.Parameters.AddWithValue("@copiesSold", gameObject.CopiesSold);
                    command.Parameters.AddWithValue("@gameSummary", gameObject.GameSummary);
                    command.Parameters.AddWithValue("@price", gameObject.Price);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "UpdateGame", "DAL", "Error");
            }
        }
        public GameDO ViewGameByID(Int64 GameID)
        {
            GameDO gameObject = new GameDO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_GAME_BY_ID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@gameID", GameID);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    gameObject.GameID = reader.GetInt64(0);
                    gameObject.GameTitle = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        gameObject.RomanNumeral = reader.GetString(2);
                    }
                    else
                    {

                    }
                    gameObject.ReleaseDate = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        gameObject.CopiesSold = reader.GetInt32(4);
                    }
                    else
                    {

                    }
                    gameObject.GameSummary = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                    {
                        gameObject.Price = reader.GetDecimal(6);
                    }
                    else
                    {

                    }
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "ViewGameByID", "DAL", "Error");
            }
            return gameObject;
        }
        public List<GameDO> ViewGameID()
        {
            List<GameDO> gameList = new List<GameDO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_GAME_IDS", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GameDO gameObject = new GameDO();
                        gameObject.GameID = reader.GetInt64(0);
                        gameObject.GameTitle = reader.GetString(1);
                        gameList.Add(gameObject);
                    }
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "ViewGameID", "DAL", "Error");
            }
            return gameList;
        }
    }
}
