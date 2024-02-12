using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class WorkingLifeController : Controller
    {
        WorkingLifeRepository repo = new WorkingLifeRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult WorkingLifeAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WorkingLifeAdd(WorkingLife model)
        {
            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        public ActionResult WorkingLifeDelete(int id)
        {
            var workingId = repo.TFind(x => x.ID == id);
            repo.TDelete(workingId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult WorkingLifeUpdate(int id)
        {
            var workingId = repo.TFind(x => x.ID == id);
            return View(workingId);
        }
        [HttpPost]
        public ActionResult WorkingLifeUpdate(WorkingLife model)
        {
            var working = repo.TFind(x => x.ID == model.ID);
            working.Title = model.Title;
            working.CompanyName = model.CompanyName;
            working.WorkingDate = model.WorkingDate;
            working.Content = model.Content;
            repo.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}