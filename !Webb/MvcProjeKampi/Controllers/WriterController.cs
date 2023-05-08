using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;
using PagedList;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        private WriterMenager wm = new WriterMenager(new EfWriterDal());
        WriterValidator wvalidator = new WriterValidator();
        public ActionResult Index(int p = 1)
        {
            var writerValues = wm.GetList().ToPagedList(p,9);
            return View(writerValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult result = wvalidator.Validate(p);
            if (result.IsValid)
            {
                if (Request.Files.Count>0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/AdminLTE-3.0.4/writerimg/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.WriterImage = "/AdminLTE-3.0.4/writerimg/" + dosyaadi + uzanti;
                }
                p.WriterDateTime =DateTime.Parse(DateTime.Now.ToShortDateString());
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult result = wvalidator.Validate(p);
            if (result.IsValid)
            {
                if (Request.Files.Count>0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/AdminLTE-3.0.4/writerimg/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.WriterImage = "/AdminLTE-3.0.4/writerimg/" + dosyaadi + uzanti;
                }

                p.WriterDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}