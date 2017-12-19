using FinalFantasyDAL;
using FinalFantasyDAL.Models;
using FinalFantasyMVC.Mapper;
using FinalFantasyMVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinalFantasyMVC.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        [HttpGet]
        public ActionResult Index()
        {
            ActionResult response = null;
            if (Session["UserName"] != null)
            {
                GameDL dl = new GameDL();
                GameMap map = new GameMap();
                List<GamePO> fullList = new List<GamePO>();
                List<GameDO> allData = dl.ViewGames();
                foreach (GameDO data in allData)
                {
                    GamePO mappedData = map.GameDOToPO(data);
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
        public ActionResult CreateGame()
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] == 3)
            {
                GamePO gameObject = new GamePO();
                response = View(gameObject);
            }
            else
            {
                response = RedirectToAction("Index");
            }
            return response;
        }
        [HttpPost]
        public ActionResult CreateGame(GamePO form)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] == 3)
            {
                GameDL dl = new GameDL();
                GameMap map = new GameMap();
                if (ModelState.IsValid)
                {
                    GameDO gameDO = map.GamePOToDO(form);
                    dl.CreateGame(gameDO);
                    response = RedirectToAction("Index");
                }
                else
                {
                    response = View(form);
                }
            }
            else
            {
                response = RedirectToAction("Index");
            }
            return response;
        }
        [HttpGet]
        public ActionResult UpdateGame(Int64 gameID)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] == 3)
            {
                GameMap map = new GameMap();
                GameDL dl = new GameDL();
                GameDO gameObject = dl.ViewGameByID(gameID);
                GamePO form = map.GameDOToPO(gameObject);
                response = View(form);
            }
            else
            {
                response = RedirectToAction("Index");
            }
            return response;
        }
        [HttpPost]
        public ActionResult UpdateGame(GamePO form)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] == 3)
            {
                GameDL dl = new GameDL();
                GameMap map = new GameMap();
                if (ModelState.IsValid)
                {
                    GameDO gameObject = map.GamePOToDO(form);
                    dl.UpdateGame(gameObject);
                    response = RedirectToAction("Index");
                }
                else
                {
                    response = View(form);
                }
            }
            else
            {
                response = RedirectToAction("Index");
            }
            return response;
        }
        [HttpGet]
        public ActionResult DeleteGame(Int64 gameID)
        {
            if ((Int64)Session["RoleID"] == 3)
            {
                GameDL dl = new GameDL();
                dl.DeleteGame(gameID);
            }
            else
            {
            }
            return RedirectToAction("Index");
        }
    }
}