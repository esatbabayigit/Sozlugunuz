using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DictionaryAllController : Controller
    {
        private WriterMenager wm = new WriterMenager(new EfWriterDal());
        private HeadingMenager hm = new HeadingMenager(new EfHeadingDal());
        private ContentMenager cm = new ContentMenager(new EfContentDal());
        public ActionResult Index()
        {
            var writervalue = wm.GetList();
            return View(writervalue);
        }

        public ActionResult LayoutPage(int p=1,string yazi="" ,int ses=0)
        {
            if (ses==1)
            {
                yazi = "";
                Random rnd = new Random();
                var contentvalue = cm.GetList().Where(x => x.Heading.HeadingName.Length <= 20 && x.ContentValue.Length <= 225).OrderBy(x => rnd.Next()).Take(21).ToList().ToPagedList(p, 21);
                ViewBag.typs = 0;
                ViewBag.count = contentvalue.Count;
                return View(contentvalue);
            }
            else
            {
                Random rnd = new Random();
                if (yazi=="")
                {
                    var contentvalue = cm.GetList().Where(x => x.Heading.HeadingName.Length <= 20 && x.ContentValue.Length <= 225 && (x.Heading.HeadingName.Contains(yazi))).OrderBy(x => rnd.Next()).Take(21).ToList().ToPagedList(p, 21);
                    ViewBag.count = contentvalue.Count;
                    ViewBag.typs = 0;
                    return View(contentvalue);
                }
                else
                {
                    var contentvalue = cm.GetList().Where(x => x.Heading.HeadingName.Length <= 20 && x.ContentValue.Length <= 225 && (x.Heading.HeadingName.Contains(yazi))).ToList().ToPagedList(p,21);
                    ViewBag.count = contentvalue.Count;
                    ViewBag.typs = 1;
                    ViewBag.yazi = yazi;
                    return View(contentvalue);
                }
                
            }
        }

        public ActionResult LayoutPageWriterProfile(int id)
        {
            Random rnd = new Random();
            var contentvalue = cm.GetList().Where(x =>x.WriterID==id).Take(1).ToList();
            return View(contentvalue);
        }

        public ActionResult LayoutPageErrorPage()
        {
            return View();
        }
    }
}