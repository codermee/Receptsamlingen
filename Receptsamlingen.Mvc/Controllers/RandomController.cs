﻿using System;
using System.Web.Mvc;
using Receptsamlingen.Mvc.Classes;

namespace Receptsamlingen.Mvc.Controllers
{
    public class RandomController : Controller
    {
        public ActionResult Randomize()
        {
			var idList = SessionHandler.RecipeIdList;
			var total = idList.Count;
			var randomNumber = new Random().Next(0, total - 1);
			var generatedRecipeId = idList[randomNumber];
			return RedirectToAction("Id", "Recipe",  new { id = generatedRecipeId });
        }
    }
}