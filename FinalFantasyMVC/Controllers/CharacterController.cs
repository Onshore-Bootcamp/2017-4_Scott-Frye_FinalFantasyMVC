using FinalFantasyDAL;
using FinalFantasyDAL.Models;
using FinalFantasyMVC.Mapper;
using FinalFantasyMVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinalFantasyMVC.Controllers
{
    public class CharacterController : Controller
    {
        private CharacterDL dl = new CharacterDL();
        [HttpGet]
        // GET: Character
        public ActionResult CharacterIndex(Int64 gameID)
        {
            ActionResult response = null;
            if (Session["UserName"] != null)
            {
                CharacterMap map = new CharacterMap();
                List<CharacterPO> fullList = new List<CharacterPO>();
                List<CharacterDO> allData = dl.ViewCharactersByGame(gameID);
                foreach (CharacterDO data in allData)
                {
                    CharacterPO mappedData = map.CharacterDOToPO(data);
                    fullList.Add(mappedData);
                }
                ViewBag.GameId = gameID;
                response = View(fullList);
            }
            else
            {
                response = RedirectToAction("Index", "Game");
            }
            return response;
        }
        [HttpGet]
        public ActionResult CreateCharacter(long gameId)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] >= 2)
            {
                ViewBag.GameID = gameId;
                CharacterPO characterObject = new CharacterPO();
                response = View(characterObject);
            }
            else
            {
                response = RedirectToAction("Index", "Game");
            }
            return response;
        }
        [HttpPost]
        public ActionResult CreateCharacter(CharacterPO form)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] >= 2)
            {
                CharacterMap map = new CharacterMap();
                if (ModelState.IsValid)
                {
                    CharacterDO characterObject = map.CharacterPOToDO(form);

                    dl.CreateCharacter(characterObject);
                    response = RedirectToAction("CharacterIndex", new { gameID = form.GameID });
                }
                else
                {
                    ViewBag.gameID = form.GameID;
                    response = View(form);
                }
            }
            else
            {
                response = RedirectToAction("CharacterIndex", new { gameID = form.GameID });
            }
            return response;
        }
        [HttpGet]
        public ActionResult UpdateCharacter(Int64 characterID, long gameId)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] >= 2)
            {
                ViewBag.GameID = gameId;
                CharacterMap map = new CharacterMap();
                CharacterDO characterObject = dl.ViewCharacterByID(characterID);
                CharacterPO form = map.CharacterDOToPO(characterObject);
                response = View(form);
            }
            else
            {
                response = RedirectToAction("CharacterIndex", new { gameID = gameId });
            }
            return response;
        }
        [HttpPost]
        public ActionResult UpdateCharacter(CharacterPO form)
        {
            ActionResult response = null;
            if ((Int64)Session["RoleID"] >= 2)
            {
                CharacterMap map = new CharacterMap();
                if (ModelState.IsValid)
                {
                    CharacterDO characterObject = map.CharacterPOToDO(form);
                    dl.UpdateCharacter(characterObject);
                    response = RedirectToAction("CharacterIndex", new { gameID = form.GameID });
                }
                else
                {
                    ViewBag.gameID = form.GameID;
                    response = View(form);
                }
            }
            else
            {
                response = RedirectToAction("CharacterIndex", new { gameID = form.GameID });
            }
            return response;
        }
        [HttpGet]
        public ActionResult DeleteCharacter(Int64 characterID, long gameId)
        {
            if ((Int64)Session["RoleID"] == 3)
            {
                ViewBag.GameID = gameId;
                dl.DeleteCharacter(characterID);
            }
            else
            {

            }
            return RedirectToAction("CharacterIndex", new { gameID = gameId });
        }
    }
}