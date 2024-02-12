using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;

namespace PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        GenericRepository<Slider> repoSlider = new GenericRepository<Slider>();
        GenericRepository<About> repoAbout = new GenericRepository<About>();
        GenericRepository<Skill> repoSkill = new GenericRepository<Skill>();
        GenericRepository<Portfolio> repoPortfolio = new GenericRepository<Portfolio>();
        GenericRepository<Service> repoService = new GenericRepository<Service>();
        GenericRepository<Education> repoEducation = new GenericRepository<Education>();
        GenericRepository<WorkingLife> repoWorkingLife = new GenericRepository<WorkingLife>();
        GenericRepository<Contact> repoContact = new GenericRepository<Contact>();
        GenericRepository<SiteSettings> repoSettings = new GenericRepository<SiteSettings>();
        //sınıf çağırma, nesne oluşturma
        public ActionResult Index()
		{
            return View();
		}
        public PartialViewResult Slider()
		{
            var result = repoSlider.List();
            //int, string, double, bool, List<int> = var
            return PartialView(result);
		}
        public PartialViewResult About()
		{
            var result = repoAbout.List();
            return PartialView(result);
		}
        public PartialViewResult Skills()
		{
            var result = repoSkill.List();
            return PartialView(result);
		}
        public PartialViewResult Portfilo()
		{
            var result = repoPortfolio.List();
            return PartialView(result);
		}
        public PartialViewResult Service()
		{
            var result = repoService.List();
            return PartialView(result);
		}
        public PartialViewResult Resume()
		{
            return PartialView();
		}
        public PartialViewResult Education()
		{
            var result = repoEducation.List();
            return PartialView(result);
		}
        public PartialViewResult WorkingLife()
		{
            List<WorkingLife> result = repoWorkingLife.List();
            return PartialView(result);
		}
        public PartialViewResult Counter()
		{
            return PartialView();
		}
        [HttpGet]
        public PartialViewResult Contact()
		{
            return PartialView();
		}
        [HttpPost]
        public PartialViewResult Contact(Contact contact)
		{
            contact.MessageDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            repoContact.TAdd(contact);
            return PartialView();
		}
        public PartialViewResult CopyRigth()
		{
            var result = repoSettings.List();
            return PartialView(result);
		}
        public PartialViewResult SliderInfoSite()
		{
            var result = repoSettings.List();
            return PartialView(result);
		}
    }
}