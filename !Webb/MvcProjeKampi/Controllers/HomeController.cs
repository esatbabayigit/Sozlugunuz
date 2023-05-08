using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        private ContactMenager cm = new ContactMenager(new EfContactDal());
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage(Contact p,int parameter=0)
        {
            if (parameter==1)
            {
                p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.ContactAdd(p);
            }
            Context c = new Context();
            ViewBag.heading = c.Headings.Count();
            ViewBag.writer = c.Writers.Count();
            ViewBag.article=c.Contents.Count();
            ViewBag.category=c.Categories.Count();
            return View();
        }
        [HttpPost]
        public ActionResult LoginDirect(string logindirect)
        {
            if (logindirect=="writer")
            {
                return RedirectToAction("WriterLogin", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}