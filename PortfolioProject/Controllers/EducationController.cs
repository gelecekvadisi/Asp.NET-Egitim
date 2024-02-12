using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class EducationController : Controller
    {
        EducationRepository repo = new EducationRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult EducationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EducationAdd(Education model)
        {
            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        public ActionResult EducationDelete(int id)
        {
            var education = repo.TFind(x => x.ID == id);
            repo.TDelete(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EducationUpdate(int id)
        {
            var educationId = repo.TFind(x => x.ID == id);
            return View(educationId);
        }
        [HttpPost]
        public ActionResult EducationUpdate(Education model)
        {
            var education = repo.TFind(x => x.ID == model.ID);
            education.Title = model.Title;
            education.Scholl = model.Scholl;
            education.EducationDate = model.EducationDate;
            education.Content = model.Content;
            repo.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}