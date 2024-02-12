using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        ServiceRepository repo = new ServiceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult ServiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ServiceAdd(Service model)
        {
            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ServiceUpdate(int id)
        {
            var serviceId = repo.TFind(x => x.ID == id);
            return View(serviceId);
        }
        [HttpPost]
        public ActionResult ServiceUpdate(Service model)
        {
            var service = repo.TFind(x => x.ID == model.ID);
            service.Title = model.Title;
            service.Content = model.Content;
            repo.TUpdate(model);
            return RedirectToAction("Index");
        }
        public ActionResult ServiceDelete(int id)
        {
            var service = repo.TFind(x => x.ID == id);
            repo.TDelete(service);
            return RedirectToAction("Index");
        }
    }
}