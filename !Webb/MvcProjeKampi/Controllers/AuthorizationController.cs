using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        private AdminMenager am = new AdminMenager(new EfAdminDal());
        public ActionResult Index(int value=0)
        {
            ViewBag.value = value;
            var adminvalues = am.GetList();
            var adminmainrole = (string)Session["AdminRole"];
            ViewBag.ar = adminmainrole;
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        public ActionResult AddAdmin(Admin p)
        {

            am.AdminAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var adminvalue = am.GetById(id);
            if (adminvalue.AdminStatus == false)
            {
                adminvalue.AdminStatus = true;
                am.AdminUpdate(adminvalue);
                return RedirectToAction("Index");
            }

            else
            {
                adminvalue.AdminStatus = false;
                am.AdminUpdate(adminvalue);
                return RedirectToAction("Index");
            }

        }

        public ActionResult ChangeAdminRole(int id)
        {
            var adminrole = am.GetById(id);
            var adminmainrole = (string)Session["AdminRole"];
            int value = 0;
            if (adminmainrole == "A")
            {
                if (adminrole.AdminRole == "A")
                {
                    value = 1;
                    return RedirectToAction("Index",new RouteValueDictionary(new {value=value}));
                }
                if (adminrole.AdminRole == "B")
                {
                    adminrole.AdminRole = "C";
                    am.AdminUpdate(adminrole);
                    return RedirectToAction("Index");
                }
                else
                {
                    adminrole.AdminRole = "A";
                    am.AdminUpdate(adminrole);
                    return RedirectToAction("Index");
                }
            }
            if (adminmainrole == "B")
            {
                if (adminrole.AdminRole=="A")
                {
                    value = 2;
                    return RedirectToAction("Index", new RouteValueDictionary(new { value = value }));
                }
                if (adminrole.AdminRole == "B")
                {
                    adminrole.AdminRole = "C";
                    am.AdminUpdate(adminrole);
                    return RedirectToAction("Index");
                }
                else
                {
                    adminrole.AdminRole = "B";
                    am.AdminUpdate(adminrole);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                value = 3;
                return RedirectToAction("Index", new RouteValueDictionary(new { value = value }));
            }

        }
    }
}