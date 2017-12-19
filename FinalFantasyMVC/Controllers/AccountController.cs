using FinalFantasyDAL;
using FinalFantasyDAL.Models;
using FinalFantasyMVC.Models;
using System.Web.Mvc;

namespace FinalFantasyMVC.Controllers
{
    public class AccountController : Controller
    {
        private AccountDataAccess accountDataAccess = new AccountDataAccess();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            ActionResult response = null;
            if (Session["UserName"] == null)
            {
                LoginPO login = new LoginPO();
                response = View(login);
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            return response;
        }
        [HttpPost]
        public ActionResult Login(LoginPO form)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                UserDO storedInfo = accountDataAccess.ViewUserByUsername(form.UserName);
                if (form.UserPassword == storedInfo.UserPassword && form.UserName == storedInfo.UserName)
                {
                    Session["UserName"] = storedInfo.UserName;
                    Session["RoleID"] = storedInfo.RoleID;
                    result = RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong username and password");
                    result = View(form);
                }
            }
            else
            {
                result = View(form);
            }
            return result;
            
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            ActionResult response = null;
            if (Session["UserName"] != null)
            {
                Session.Abandon();
                response = RedirectToAction("Login");
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            return response;
        }
    }
}