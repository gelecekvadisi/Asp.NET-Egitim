using PortfolioProject.Models.Entity;
using PortfolioProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class SkillController : Controller
    {
        SkillRepository repo = new SkillRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SkillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillAdd(Skill model)
        {
            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        public ActionResult SkillDelete(int id)
        {
            var skillInfo = repo.TFind(x => x.ID == id);
            repo.TDelete(skillInfo);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SkillUpdate(int id)
        {
            var values = repo.TFind(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult SkillUpdate(Skill model)
        {
            var skillInfo = repo.TFind(x => x.ID == model.ID);
            skillInfo.Title = model.Title;
            skillInfo.Percent = model.Percent;
            repo.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}