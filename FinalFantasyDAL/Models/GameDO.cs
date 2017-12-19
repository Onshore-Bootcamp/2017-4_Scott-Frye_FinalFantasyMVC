using System;

namespace FinalFantasyDAL.Models
{
    public class GameDO
    {
        public GameDO()
        {
            
        }
        public GameDO (Int64 gameID, string gameTitle, string romanNumeral, string releaseDate, int copiesSold, string gameSummary, decimal price)
        {
            GameID = gameID;
            GameTitle = gameTitle;
            RomanNumeral = romanNumeral;
            ReleaseDate = releaseDate;
            CopiesSold = copiesSold;
            GameSummary = gameSummary;
            Price = price;
        }
        public Int64 GameID { get; set; }
        public string GameTitle { get; set; }
        public string RomanNumeral { get; set; }
        public string ReleaseDate { get; set; }
        public int CopiesSold { get; set; }
        public string GameSummary { get; set; }
        public decimal Price { get; set; }
    }
}
