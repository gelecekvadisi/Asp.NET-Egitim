using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
	public class PortfolioController : Controller
	{
		PortfolioRepository repo = new PortfolioRepository();
		public ActionResult List()
		{
			List<Portfolio> values = repo.List();
			return View(values);
		}
		[HttpGet]
		public ActionResult PortfolioAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult PortfolioAdd(Portfolio model)
		{
			if (!ModelState.IsValid) //eğer veriler doğru değilse
			{
				return View("PortfolioAdd");
			}			
			model.AddDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //DateTime.Now
			repo.TAdd(model);
			return RedirectToAction("List");
		}
		public ActionResult PortfolioDelete(int id)
		{
			var portfolioInfo = repo.TFind(x => x.ID == id);
			repo.TDelete(portfolioInfo);
			return RedirectToAction("List");
		}
		[HttpGet]
		public ActionResult PortfolioUpdate(int id)
		{
			var portfolioId = repo.TFind(x => x.ID == id);
			return View(portfolioId);
		}
		[HttpPost]
		public ActionResult PortfolioUpdate(Portfolio model)
		{
			if (!ModelState.IsValid) //eğer veriler doğru değilse
			{
				return View("PortfolioUpdate");
			}
			var portfolio = repo.TFind(x => x.ID == model.ID);
			portfolio.Title = model.Title;
			portfolio.Image = model.Image;
			portfolio.AddDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			repo.TUpdate(model);
			return RedirectToAction("List");
		}
	}
}