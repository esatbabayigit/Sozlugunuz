using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private AdminMenager am = new AdminMenager(new EfAdminDal());
        private AdminLoginMenager alm = new AdminLoginMenager(new EfAdminDal());
        private WriterMenager wm = new WriterMenager(new EfWriterDal());
        private WriterLoginMenager wlm = new WriterLoginMenager(new EfWriterDal());
        [HttpGet][AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {

            var adminlogin = alm.GetAdminLogin(p.AdminUserName, p.AdminPassword);
            if (adminlogin!=null)
            {
                ViewBag.param = true;
                FormsAuthentication.SetAuthCookie(adminlogin.AdminUserName,false);
                Session["AdminUserName"] = adminlogin.AdminUserName;
                Session["AdminRole"] = adminlogin.AdminRole;
                if (adminlogin.AdminRole=="A")
                {
                    return RedirectToAction("Index", "AdminCategoryController");
                }
                else
                {
                    return RedirectToAction("Index", "Heading");
                }
                
            }
            else
            {
                ViewBag.param = false;
                return View(ViewBag.param);
            }
           
        }

        //Hata Pop up ı
        public PartialViewResult ErrorPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var writerlogin = wlm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writerlogin != null)
            {
                ViewBag.param = true;
                FormsAuthentication.SetAuthCookie(writerlogin.WriterMail, false);
                Session["WriterMail"] = writerlogin.WriterMail;
                return RedirectToAction("Index", "WriterPanelProfile");
            }
            else
            {
                ViewBag.param = false;
                return View(ViewBag.param);
            }
          
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}