
using FinalFantasyMVC.ViewModels;
using System.Data.SqlClient;

namespace FinalFantasyMVC.CustomCode
{
    public class ExceptionAnalysis
    {

        public string GenerateResponse(SqlException sqlEx)
        {
            string message = "";

            switch(sqlEx.Number)
            {
                case 2627:
                    message = "Username already exists.";
                    break;
            }

            return message;
        }
    }
}