using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class SettingsController : Controller
    {
        SettingsRepository repo = new SettingsRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SettingsUpdate(int id)
        {
            var settings = repo.TFind(x => x.ID == id);
            return View(settings);
        }
        [HttpPost]
        public ActionResult SettingsUpdate(SiteSettings model)
        {
            var setting = repo.TFind(x => x.ID == model.ID);
            setting.Address = model.Address;
            setting.Email = model.Email;
            setting.Phone = model.Phone;
            setting.FacebookLink = model.FacebookLink;
            setting.InstagramLink = model.InstagramLink;
            setting.LinkedinLink = model.LinkedinLink;
            setting.TwitterLink = model.TwitterLink;
            repo.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}