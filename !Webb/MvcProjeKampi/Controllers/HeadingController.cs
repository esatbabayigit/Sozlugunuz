using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;
using Microsoft.Ajax.Utilities;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class HeadingController : Controller
    {
        private HeadingMenager hm = new HeadingMenager(new EfHeadingDal());
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private WriterMenager wm = new WriterMenager(new EfWriterDal());
        public ActionResult Index(int? id, int p = 1,string yazi="",int ses=0)
        {
            if (ses==1)
            {
                yazi = "";
                if (id != null)
                {
                    var headingvalues = hm.GetListSearch(yazi).Where(x => x.CategoryID == id).ToList().ToPagedList(p, 10);
                    return View(headingvalues);
                }
                else
                {
                    var headingvalues = hm.GetListSearch(yazi).ToPagedList(p, 10);
                    return View(headingvalues);
                }
            }
            else
            {
                if (id != null)
                {
                    var headingvalues = hm.GetListSearch(yazi).Where(x => x.CategoryID == id).ToList().ToPagedList(p, 10);
                    return View(headingvalues);
                }
                else
                {
                    var headingvalues = hm.GetListSearch(yazi).ToPagedList(p, 10);
                    return View(headingvalues);
                }
            }
            
            
        }

        //Raporlama
        public ActionResult HeadingReport()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }








        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = categoryvalue;

            List<SelectListItem> writeritems = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.wit = writeritems;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult HeadingDelete(int id)
        {
            var headingvalue = hm.GetById(id);
            if (headingvalue.HeadingStatus == false)
            {
                headingvalue.HeadingStatus = true;
                hm.HeadingUpdate(headingvalue);
                return RedirectToAction("Index");
            }
            else
            {
                headingvalue.HeadingStatus = false;
                hm.HeadingUpdate(headingvalue);
                return RedirectToAction("Index");
            }
        }



    }
}