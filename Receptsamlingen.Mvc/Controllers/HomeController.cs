﻿using System.Web.Mvc;
using Logger;
using Ninject;
using Receptsamlingen.Mvc.Classes;
using Receptsamlingen.Mvc.Models;
using Receptsamlingen.Repository.Interfaces;

namespace Receptsamlingen.Mvc.Controllers
{
	public class HomeController : Controller
	{
		[Inject]
		public IRecipeRepository RecipeRepository { get; set; }

		public HomeController()
		{
            ViewBag.Title = "Start";
			this.Inject();
        }

		public ActionResult Index()
		{
			var recipes = RecipeRepository.GetLatest(SessionHandler.ForceReload);
			SetRecipeIdList();

			var model = new HomeModel
				{
					Recipes = recipes
				};
			return View(model);
		}

		private void SetRecipeIdList()
		{
			var idList = RecipeRepository.GetAllIds();
			if (idList != null && idList.Count > 0)
			{
				SessionHandler.RecipeIdList = idList;
			}
		}
	}
}