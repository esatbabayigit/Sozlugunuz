using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private AboutMenager am = new AboutMenager(new EfAboutDal());
        public ActionResult Index(int p = 1,string yazi="",int ses=0)
        {
            if (ses==1)
            {
                yazi = "";
                var aboutValues = am.GetListSearch(yazi).ToPagedList(p, 15);
                return View(aboutValues);
            }
            else
            {
                var aboutValues = am.GetListSearch(yazi).ToPagedList(p, 15);
                return View(aboutValues);
            }
            
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult EditAbout(int id)
        {
            var aboutValues = am.GetById(id);
            if (aboutValues.AboutStatus == true)
            {
                aboutValues.AboutStatus = false;
                am.AboutUpdate(aboutValues);
            }
            else
            {
                aboutValues.AboutStatus = true;
                am.AboutUpdate(aboutValues);
            }
            return RedirectToAction("Index");
        }
    }
}