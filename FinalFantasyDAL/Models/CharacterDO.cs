using System;

namespace FinalFantasyDAL.Models
{
    public class CharacterDO
    {
        public CharacterDO()
        {

        }
        public CharacterDO(Int64 characterID, string firstName, string lastName, Int64 gameID, string alignment, string weaponOfChoice, string bio, string maleOrFemale)
        {
            CharacterID = characterID;
            FirstName = firstName;
            LastName = lastName;
            GameID = gameID;
            Alignment = alignment;
            WeaponOfChoice = weaponOfChoice;
            Bio = bio;
            MaleOrFemale = maleOrFemale;
        }
        public Int64 CharacterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 GameID { get; set; }
        public string Alignment { get; set; }
        public string WeaponOfChoice { get; set; }
        public string Bio { get; set; }
        public string MaleOrFemale { get; set; }
    }
}
