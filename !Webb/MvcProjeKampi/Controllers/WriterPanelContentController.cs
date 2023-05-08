using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class WriterPanelContentController : Controller
    {
        private ContentMenager cm = new ContentMenager(new EfContentDal());
        private Context c = new Context();
        public ActionResult MyContent(int? id, int p = 1,string yazi="",int ses=0)
        {
            if (ses==1)
            {
                yazi = "";
                if (id == null)
                {
                    Context c = new Context();
                    var s = (string)Session["WriterMail"];
                    var writeridinfo = c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterID).FirstOrDefault();
                    var contentcvalues = cm.GetListByWriter(writeridinfo, yazi).ToPagedList(p, 20);
                    if (contentcvalues == null)
                    {
                        ViewBag.values = 1;
                    }
                    else
                    {
                        ViewBag.values = 0;
                    }
                    return View(contentcvalues);
                }
                else
                {
                    Context c = new Context();
                    var s = (string)Session["WriterMail"];
                    var writeridinfo = c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterID).FirstOrDefault();
                    var contentcvalues = cm.GetListByWriterPrivateContent(writeridinfo, id, yazi).ToPagedList(p, 20);
                    if (contentcvalues.Count == 0)
                    {
                        ViewBag.values = 1;
                    }
                    else
                    {
                        ViewBag.values = 0;
                    }
                    return View(contentcvalues);
                }
            }
            else
            {
                if (id == null)
                {
                    Context c = new Context();
                    var s = (string)Session["WriterMail"];
                    var writeridinfo = c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterID).FirstOrDefault();
                    var contentcvalues = cm.GetListByWriter(writeridinfo, yazi).ToPagedList(p, 20);
                    if (contentcvalues == null)
                    {
                        ViewBag.values = 1;
                    }
                    else
                    {
                        ViewBag.values = 0;
                    }
                    return View(contentcvalues);
                }
                else
                {
                    Context c = new Context();
                    var s = (string)Session["WriterMail"];
                    var writeridinfo = c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterID).FirstOrDefault();
                    var contentcvalues = cm.GetListByWriterPrivateContent(writeridinfo, id, yazi).ToPagedList(p, 20);
                    if (contentcvalues.Count == 0)
                    {
                        ViewBag.values = 1;
                    }
                    else
                    {
                        ViewBag.values = 0;
                    }
                    return View(contentcvalues);
                }
            }
           
        }

    }
}