using FinalFantasyDAL;
using FinalFantasyDAL.Models;
using FinalFantasyMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using FinalFantasyMVC.Mapper;
using System;
using System.Data.SqlClient;
using FinalFantasyMVC.ViewModels;
using FinalFantasyMVC.CustomCode;

namespace FinalFantasyMVC.Controllers
{
    public class UserController : Controller
    {
        private UserDL userDL = new UserDL();
        [HttpGet]
        public ActionResult UserIndex()
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] == 3)
            {
                UserMap map = new UserMap();
                List<UserPO> fullList = new List<UserPO>();
                List<UserDO> allData = userDL.ViewUsers();
                foreach (UserDO data in allData)
                {
                    UserPO mappedData = map.UserDOToPO(data);
                    fullList.Add(mappedData);
                }
                response = View(fullList);
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            return response;
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            ActionResult response = null;
            if (Session["UserName"] == null)
            {
                UserViewModel userInfo = new UserViewModel();
                response = View(userInfo);
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            return response;
        }
        [HttpPost]
        public ActionResult CreateUser(UserViewModel userInfo)
        {
            ActionResult response = null;
            try
            {
                if (Session["UserName"] == null)
                {
                    UserPO form = userInfo.Form;
                    if (ModelState.IsValid)
                    {
                        UserMap map = new UserMap();
                        UserDO userObject = map.UserPOToDO(form);
                        userObject.RoleID = 1;
                        userDL.CreateUser(userObject);
                        response = RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        response = View(userInfo);
                    }
                }
                else
                {
                    response = RedirectToAction("Index", "Home");
                }
            }
            catch (SqlException sqlEx)
            {
                //What about the exception do we wish to analyze?
                userInfo.message = new ExceptionAnalysis().GenerateResponse(sqlEx);
                response = View(userInfo);
            }
            return response;
        }
        [HttpGet]
        public ActionResult UpdateUser(int UserID)
        {
            ActionResult response = null;
            UserViewModel vm = new UserViewModel();
            if ((Int64)Session["RoleID"] == 3)
            {
                UserMap map = new UserMap();
                UserDO userObject = userDL.GetUserByID(UserID);
                vm.Form = map.UserDOToPO(userObject);
                response = View(vm);
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            return response;
        }
        [HttpPost]
        public ActionResult UpdateUser(UserViewModel userInfo)
        {
            ActionResult response = null;
            try
            {
                if ((Int64)Session["RoleID"] == 3)
                {
                    UserPO form = userInfo.Form;
                    UserMap map = new UserMap();
                    if (ModelState.IsValid)
                    {
                        UserDO userObject = map.UserPOToDO(form);
                        userDL.UpdateUser(userObject);
                        response = RedirectToAction("UserIndex");
                    }
                    else
                    {
                        response = View(userInfo);
                    }
                }
                else
                {
                    response = RedirectToAction("Index", "Home");
                }
            }
            catch(SqlException sqlEx)
            {
                userInfo.message = new ExceptionAnalysis().GenerateResponse(sqlEx);
                response = View(userInfo);
            }
            return response;
        }
        [HttpGet]
        public ActionResult DeleteUser(Int64 userID)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] == 3)
            {

                userDL.DeleteUser(userID);
                response = RedirectToAction("UserIndex");
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            return response;
        }
    }
}