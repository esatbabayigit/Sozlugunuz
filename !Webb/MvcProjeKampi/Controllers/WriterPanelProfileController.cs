using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelProfileController : Controller
    {
        private WriterMenager wm = new WriterMenager(new EfWriterDal());
        public ActionResult Index(int id=0)
        {
            Context c = new Context();
            var writermails = (string)Session["WriterMail"];
            if (writermails!=null)
            {
                ViewBag.ses = 2;
                var ids = c.Writers.Where(x => x.WriterMail == writermails).Select(y => y.WriterID).FirstOrDefault();
                var writerlist = wm.GetListByWriterId(ids);
                return View(writerlist);
            }
            else
            {
                ViewBag.ses = 1;
                var ids = id;
                var writerlist = wm.GetListByWriterId(ids);
                return View(writerlist);
            }
            
            
        }
    }
}