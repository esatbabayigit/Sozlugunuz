using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private ImageFileMenager im = new ImageFileMenager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}