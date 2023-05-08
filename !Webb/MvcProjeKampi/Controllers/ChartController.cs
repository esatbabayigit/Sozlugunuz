using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private HeadingMenager hm = new HeadingMenager(new EfHeadingDal());
        public ActionResult Index()
        {
            ViewBag.categorycontent = hm.GetList();
            return View();
        }

        public ActionResult CategoryChart()
        {
            ViewBag.categorycontent = cm.GetList().Count;
            return Json(cm.GetListChart(), JsonRequestBehavior.AllowGet);
        }
    }
}