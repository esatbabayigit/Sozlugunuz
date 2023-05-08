using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;

namespace MvcProjeKampi.Controllers
{
    public class TestController : Controller
    {
        private HeadingMenager hm = new HeadingMenager(new EfHeadingDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SweetAlert()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult TryLayout()
        {
            var headlist = hm.GetList();
            return View(headlist);
        }
    }
}