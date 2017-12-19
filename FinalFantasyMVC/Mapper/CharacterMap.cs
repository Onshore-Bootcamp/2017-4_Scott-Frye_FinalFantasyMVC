using FinalFantasyDAL.Models;
using FinalFantasyMVC.Models;

namespace FinalFantasyMVC.Mapper
{
    public class CharacterMap
    {
        public CharacterPO CharacterDOToPO (CharacterDO characterDO)
        {
            CharacterPO po = new CharacterPO();
            po.CharacterID = characterDO.CharacterID;
            po.FirstName = characterDO.FirstName;
            po.LastName = characterDO.LastName;
            po.GameID = characterDO.GameID;
            po.Alignment = characterDO.Alignment;
            po.WeaponOfChoice = characterDO.WeaponOfChoice;
            po.Bio = characterDO.Bio;
            po.MaleOrFemale = characterDO.MaleOrFemale;
            return po;
        }
        public CharacterDO CharacterPOToDO(CharacterPO po)
        {
            CharacterDO characterDO = new CharacterDO();
            characterDO.CharacterID = po.CharacterID;
            characterDO.FirstName = po.FirstName;
            characterDO.LastName = po.LastName;
            characterDO.GameID = po.GameID;
            characterDO.Alignment = po.Alignment;
            characterDO.WeaponOfChoice = po.WeaponOfChoice;
            characterDO.Bio = po.Bio;
            characterDO.MaleOrFemale = po.MaleOrFemale;
            return characterDO;
        }

    }
}