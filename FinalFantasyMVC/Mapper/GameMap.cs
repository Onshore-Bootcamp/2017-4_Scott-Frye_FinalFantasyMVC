using FinalFantasyDAL.Models;
using FinalFantasyMVC.Models;

namespace FinalFantasyMVC.Mapper
{
    public class GameMap
    {
        public GamePO GameDOToPO(GameDO gameDO)
        {
            GamePO gamePO = new GamePO();
            gamePO.GameID = gameDO.GameID;
            gamePO.GameTitle = gameDO.GameTitle;
            gamePO.RomanNumeral = gameDO.RomanNumeral;
            gamePO.ReleaseDate = gameDO.ReleaseDate;
            gamePO.CopiesSold = gameDO.CopiesSold;
            gamePO.GameSummary = gameDO.GameSummary;
            gamePO.Price = gameDO.Price;
            return gamePO;
        }
        public GameDO GamePOToDO(GamePO gamePO)
        {
            GameDO gameDO = new GameDO();
            gameDO.GameID = gamePO.GameID;
            gameDO.GameTitle = gamePO.GameTitle;
            gameDO.RomanNumeral = gamePO.RomanNumeral;
            gameDO.ReleaseDate = gamePO.ReleaseDate;
            gameDO.CopiesSold = gamePO.CopiesSold;
            gameDO.GameSummary = gamePO.GameSummary;
            gameDO.Price = gamePO.Price;
            return gameDO;
        }

    }
}