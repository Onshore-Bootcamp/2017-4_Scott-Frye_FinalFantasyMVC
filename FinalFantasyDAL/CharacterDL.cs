using FinalFantasyDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FinalFantasyDAL
{
    public class CharacterDL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["capstoneConnection"].ConnectionString;

        public List<CharacterDO> ViewCharactersByGame(Int64 gameID)
        {
            List<CharacterDO> characterList = new List<CharacterDO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_CHARACTERS_BY_GAME_ID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@gameID", gameID);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CharacterDO characterObject = new CharacterDO();
                        characterObject.CharacterID = reader.GetInt64(0);
                        characterObject.FirstName = reader.GetString(1);
                        characterObject.LastName = reader.GetString(2);
                        characterObject.GameID = reader.GetInt64(3);
                        characterObject.Alignment = reader.GetString(4);
                        characterObject.WeaponOfChoice = reader.GetString(5);
                        characterObject.Bio = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                        {
                            characterObject.MaleOrFemale = reader.GetString(7);
                        }
                        else
                        {

                        }
                        characterList.Add(characterObject);
                    }
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "ViewCharacterByGame", "DAL", "Error");
            }
            return characterList;
        }
        public void CreateCharacter(CharacterDO characterObject)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("CREATE_CHARACTER", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@firstName", characterObject.FirstName);
                    command.Parameters.AddWithValue("@lastName", characterObject.LastName);
                    command.Parameters.AddWithValue("@gameID", characterObject.GameID);
                    command.Parameters.AddWithValue("@alignment", characterObject.Alignment);
                    command.Parameters.AddWithValue("@weaponOfChoice", characterObject.WeaponOfChoice);
                    command.Parameters.AddWithValue("@bio", characterObject.Bio);
                    command.Parameters.AddWithValue("@maleOrFemale", characterObject.MaleOrFemale);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "CreateCharacter", "DAL", "Error");
            }
        }
        public void UpdateCharacter(CharacterDO characterObject)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE_CHARACTER", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@characterID", characterObject.CharacterID);
                    command.Parameters.AddWithValue("@firstName", characterObject.FirstName);
                    command.Parameters.AddWithValue("@lastName", characterObject.LastName);
                    command.Parameters.AddWithValue("@gameID", characterObject.GameID);
                    command.Parameters.AddWithValue("@alignment", characterObject.Alignment);
                    command.Parameters.AddWithValue("@weaponOfChoice", characterObject.WeaponOfChoice);
                    command.Parameters.AddWithValue("@bio", characterObject.Bio);
                    command.Parameters.AddWithValue("@maleOrFemale", characterObject.MaleOrFemale);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "UpdateCharacter", "DAL", "Error");
            }
        }
        public void DeleteCharacter(Int64 characterID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE_CHARACTER", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@characterID", characterID);
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.Log(ex, "DeleteCharacter", "DAL", "Error");
            }
        }
        public CharacterDO ViewCharacterByID(Int64 characterID)
        {
            CharacterDO characterObject = new CharacterDO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("VIEW_CHARACTER_BY_ID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@characterID", characterID);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    characterObject.FirstName = reader.GetString(0);
                    characterObject.LastName = reader.GetString(1);
                    characterObject.Alignment = reader.GetString(2);
                    characterObject.WeaponOfChoice = reader.GetString(3);
                    characterObject.Bio = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                    {
                        characterObject.MaleOrFemale = reader.GetString(5);
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
                error.Log(ex, "ViewCharacterByID", "DAL", "Error");
            }
            return characterObject;
        }
    }
}
