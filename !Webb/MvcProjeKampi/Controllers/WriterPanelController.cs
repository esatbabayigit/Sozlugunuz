using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using ValidationResult = FluentValidation.Results.ValidationResult;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class WriterPanelController : Controller
    {
        private HeadingMenager hm = new HeadingMenager(new EfHeadingDal());
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private WriterMenager wm = new WriterMenager(new EfWriterDal());
        private ContentMenager cms = new ContentMenager(new EfContentDal());
        private Context c = new Context();
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult WriterHeading(string s, int p = 1, string yazi = "",int ses=0)
        {
            if (ses==1)
            {
                yazi = "";
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var writeridinfo = c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterID).FirstOrDefault();
                var myheadinglist = hm.GetListByWriterSearch(writeridinfo,yazi).ToPagedList(p, 10);
                return View(myheadinglist);
            }
            else
            {
                
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var writeridinfo = c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterID).FirstOrDefault();
                var myheadinglist = hm.GetListByWriterSearch(writeridinfo, yazi).ToPagedList(p, 10);
                return View(myheadinglist);
            }
            
        }

        [HttpGet]
        public ActionResult WriterNewHeading()
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = categoryvalue;
            return View();
        }
        [HttpPost]
        public ActionResult WriterNewHeading(Heading p)
        {
            Context c = new Context();

            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var head = (string)Session["WriterMail"];
            var s = c.Writers.Where(x => x.WriterMail == head).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingStatus = true;
            p.WriterID = s;
            hm.HeadingAdd(p);
            return RedirectToAction("WriterHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
            ViewBag.vlc = categoryvalue;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("WriterHeading");
        }
        public ActionResult HeadingDelete(int id)
        {
            var headingvalue = hm.GetById(id);
            if (headingvalue.HeadingStatus == false)
            {
                headingvalue.HeadingStatus = true;
                hm.HeadingUpdate(headingvalue);
                return RedirectToAction("WriterHeading");
            }
            else
            {
                headingvalue.HeadingStatus = false;
                hm.HeadingUpdate(headingvalue);
                return RedirectToAction("WriterHeading");
            }
        }
        public ActionResult AllHeading(int p = 1,string yazi="",int ses=0)
        {
            if (ses==1)
            {
                yazi = "";
                var headinglist = hm.GetListSearch(yazi).ToPagedList(p, 10);
                return View(headinglist);
            }
            else
            {
                var headinglist = hm.GetListSearch(yazi).ToPagedList(p, 10);
                return View(headinglist);
            }
            
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            Context c = new Context();
            ViewBag.ids = id;
            var headname = c.Headings.Where(x => x.HeadingID == id).Select(y => y.HeadingName).FirstOrDefault();
            ViewBag.heads=headname;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            Context c = new Context();
            p.ContentStatus = true;
            p.ContentDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
          
            var writerid = (string)Session["WriterMail"];
            p.WriterID = c.Writers.Where(x => x.WriterMail == writerid).Select(x => x.WriterID).FirstOrDefault();
            cms.ContentAdd(p);
            return RedirectToAction("MyContent","WriterPanelContent");
        }
    }
}