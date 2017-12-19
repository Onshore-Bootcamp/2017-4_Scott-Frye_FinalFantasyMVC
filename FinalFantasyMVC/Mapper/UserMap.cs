using FinalFantasyDAL.Models;
using FinalFantasyMVC.Models;

namespace FinalFantasyMVC.Mapper
{
    public class UserMap
    {
        public UserPO UserDOToPO(UserDO userDO)
        {
            UserPO userPO = new UserPO();
            userPO.UserID = userDO.UserID;
            userPO.FullName = userDO.FullName;
            userPO.UserName = userDO.UserName;
            userPO.UserPassword = userDO.UserPassword;
            userPO.RoleID = userDO.RoleID;
            userPO.Email = userDO.Email;
            return userPO;
        }
        public UserDO UserPOToDO(UserPO userPO)
        {
            UserDO userDO = new UserDO();
            userDO.UserID = userPO.UserID;
            userDO.FullName = userPO.FullName;
            userDO.UserName = userPO.UserName;
            userDO.UserPassword = userPO.UserPassword;
            userDO.RoleID = userPO.RoleID;
            userDO.Email = userPO.Email;
            return userDO;
        }
    }
}