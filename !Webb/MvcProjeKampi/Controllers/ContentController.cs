using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        
        private ContentMenager cm = new ContentMenager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult ContentValues(string s="",int ses=0,int p=1)
        {
            if (ses==1)
            {
                s = "";
                var headingvalue = cm.GetListSearch(s).ToPagedList(p,20);
                return View(headingvalue);
            }
            else
            {
                var headingvalue = cm.GetListSearch(s).ToPagedList(p, 20);
                return View(headingvalue);
            }
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentcvalues = cm.GetListByHeadingId(id);
            return View(contentcvalues);
        }
    }
}