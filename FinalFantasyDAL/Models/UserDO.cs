using System;

namespace FinalFantasyDAL.Models
{
    public class UserDO
    {
        public UserDO()
        {

        }
        public UserDO(Int64 userID, string fullName, string userName, string userPassword, Int64 roleID, string email)
        {
            UserID = userID;
            FullName = fullName;
            UserName = userName;
            UserPassword = userPassword;
            RoleID = roleID;
            Email = email;
        }
        public Int64 UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public Int64 RoleID { get; set; }
        public string Email { get; set; }
    }
}
