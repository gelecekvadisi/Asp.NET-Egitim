using PortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
	public class ContactController : Controller
	{
		ContactRepository repo = new ContactRepository();
		public ActionResult Index()
		{
			var values = repo.List().OrderByDescending(x => x.MessageDate).ToList();
			return View(values);
		}
		public ActionResult ContactDelete(int id)
		{
			var contactId = repo.TFind(x => x.ID == id);
			repo.TDelete(contactId);
			return RedirectToAction("Index");
		}
	}
}