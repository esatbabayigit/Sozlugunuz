using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private HeadingMenager hm = new HeadingMenager(new EfHeadingDal());
        ContentMenager cm =new ContentMenager(new EfContentDal());
        public PartialViewResult Index(int id = 0)
        {
            var contenlist = cm.GetListByHeadingId(id);
            return PartialView(contenlist);
        }

        public ActionResult Headings()
        {
          
            var headlist = hm.GetList();
            return View(headlist);
        }
    }
}