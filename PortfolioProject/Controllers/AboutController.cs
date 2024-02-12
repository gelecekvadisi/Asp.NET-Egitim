using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;

namespace PortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        //Doğru Yapı 1 : 
        AboutRepository repo = new AboutRepository();
        //Doğru Yapı 2 : GenericRepository<About> repo = new GenericRepository<About>();
        public ActionResult Index()
        {
            var result = repo.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult AboutUpdate(int id)
        {
            var aboutInfo = repo.TFind(x => x.ID == id);
            return View(aboutInfo);
        }
        [HttpPost]
        public ActionResult AboutUpdate(About model)
        {
            var aboutInfo = repo.TFind(x => x.ID == model.ID);
            aboutInfo.HeadTitle = model.HeadTitle;
            aboutInfo.BigTitle = model.BigTitle;
            aboutInfo.Content = model.Content;
            repo.TUpdate(model);
            return RedirectToAction("Index");//yönlendirme
        }
    }
}
// CTRL + K + D