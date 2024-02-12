using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class SliderController : Controller
    {
        SliderRepository repo = new SliderRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SliderUpdate(int id)
        {
            var sliderInfo = repo.TFind(x => x.ID == id);
            return View(sliderInfo);
        }
        [HttpPost]
        public ActionResult SliderUpdate(Slider model)
        {
            var sliderInfo = repo.TFind(x => x.ID == model.ID);
            sliderInfo.Name = model.Name;
            sliderInfo.Job1 = model.Job1;
            sliderInfo.Job2 = model.Job2;
            sliderInfo.Job3 = model.Job3;
            repo.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}