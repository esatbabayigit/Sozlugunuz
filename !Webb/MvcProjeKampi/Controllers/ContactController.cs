using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFrameWork;
using PagedList;
using PagedList.Mvc;
namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private ContactMenager cm = new ContactMenager(new EfContactDal());
        private MessageMenager mm = new MessageMenager(new EfMessageDal());
        private ContactValidator cv = new ContactValidator();
        public ActionResult Index(string s, string yazi = "", int ses = 0, int p = 1)
        {
            if (ses == 1)
            {
                yazi = "";
                var contactvalues = cm.GetListSearch(yazi).ToPagedList(p, 10);
                Context c = new Context();
                s = (string)Session["WriterMail"];
                ViewBag.Message = mm.GetListInbox(s).Count(x => x.MessageInboxIsRead == false);
                ViewBag.Contact = cm.GetList().Count(x => x.ContactIsRead == false);
                return View(contactvalues);
            }
            else
            {
                var contactvalues = cm.GetListSearch(yazi).ToPagedList(p, 10);
                Context c = new Context();
                s = (string)Session["WriterMail"];
                ViewBag.Message = mm.GetListInbox(s).Count(x => x.MessageInboxIsRead == false);
                ViewBag.Contact = cm.GetList().Count(x => x.ContactIsRead == false);
                return View(contactvalues);
            }

        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetById(id);
            contactvalues.ContactIsRead = true;
            cm.ContactUpdate(contactvalues);
            return View(contactvalues);
        }

        public PartialViewResult ContactMenu(string p, string yazi)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            ViewBag.Message = mm.GetListInbox(p).Count(x => x.MessageInboxIsRead == false);
            ViewBag.Contact = cm.GetList().Count(x => x.ContactIsRead == false);
            return PartialView();
        }
        [HttpPost]
        public ActionResult DeleteDrafts(int[] selectedDrafts)
        {
            foreach (int id in selectedDrafts)
            {
                var deletedraft = cm.GetById(id);
                deletedraft.ContactStatus = false;
                cm.ContactUpdate(deletedraft);
            }
            return Json(new { success = true });
        }
        //halledilmiş iletişim mesajları
        public ActionResult CheckedContact(string s, int ses = 0, string yazi = "", int p = 1)
        {
            if (ses == 1)
            {
                yazi = "";
                Context c = new Context();
                s = (string)Session["AdminUserName"];
                ViewBag.usermail = s;
                var messagelist = cm.GetListDeleteSearch(yazi).ToPagedList(p, 10);
                return View(messagelist);
            }
            else
            {
                Context c = new Context();
                s = (string)Session["AdminUserName"];
                ViewBag.usermail = s;
                var messagelist = cm.GetListDeleteSearch(yazi).ToPagedList(p, 10);
                return View(messagelist);
            }
        }
        [HttpPost]
        public ActionResult DeleteContactsEnd(int[] selectedDrafts)
        {
            foreach (int id in selectedDrafts)
            {
                var deletedraft = cm.GetById(id);
                deletedraft.ContactStatusEnd = true;
                cm.ContactUpdate(deletedraft);
            }
            return Json(new { success = true });
        }
    }
}