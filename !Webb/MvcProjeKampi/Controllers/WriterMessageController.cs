using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using ValidationResult = FluentValidation.Results.ValidationResult;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class WriterMessageController : Controller
    {
        private MessageMenager mm = new MessageMenager(new EfMessageDal());
        private ContactMenager cm = new ContactMenager(new EfContactDal());


        //gönderen kişiyi session at 




        public ActionResult Inbox(string s,string yazi = "",int ses=0,int p=1)
        {
            if (ses==1)
            {
                yazi = "";
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var messagelist = mm.GetListSearch(yazi,s).ToPagedList(p,10);
                return View(messagelist);
            }
            else
            {
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var messagelist = mm.GetListSearch(yazi,s).ToPagedList(p,10);
                return View(messagelist);
            }
            
        }

        public PartialViewResult MessageMenu()
        {
            string mail = (string)Session["WriterMail"];
            ViewBag.Message = mm.GetListInbox(mail).Count(x => x.MessageInboxIsRead == false&&x.MessageDraftStatus==false&&x.MessageStatus==true);
            return PartialView();
        }
        public ActionResult Sendbox(string s, string yazi = "", int ses = 0,int p = 1)
        {
            if (ses == 1)
            {
                yazi = "";
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var messagelist = mm.GetListSendBoxSearch(s,yazi).Where(x => x.MessageStatus == true && x.MessageDraftStatus == false).ToList().ToPagedList(p,10);
                return View(messagelist);
            }
            else
            {
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var messagelist = mm.GetListSendBoxSearch(s,yazi).Where(x => x.MessageStatus == true && x.MessageDraftStatus == false).ToList().ToPagedList(p,10);
                return View(messagelist);
            }
            
        }

        //Yeni Mesaj
        [HttpGet]
        public ActionResult AddNewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewMessage(Message p, string parameter)
        {
            MessageValidator mv = new MessageValidator();
            ValidationResult vr = mv.Validate(p);
            if (vr.IsValid)
            {
                if (parameter == "send")
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.MessageSenderMail = (string)Session["WriterMail"];
                    p.MessageDraftStatus = false;
                    p.MessageStatus = true;
                    mm.MessageAdd(p);
                    return RedirectToAction("Sendbox");
                }

                if (parameter == "draft")
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.MessageSenderMail = (string)Session["WriterMail"];
                    p.MessageDraftStatus = true;
                    p.MessageStatus = true;
                    mm.MessageAdd(p);
                    return RedirectToAction("MessageDraftMenu");
                }
            }
            else
            {
                foreach (var item in vr.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //Taslak Görüntüleme Sayfası
        public ActionResult MessageDraftMenu(string s, string yazi = "", int ses = 0, int p = 1)
        {
            if (ses == 1)
            {
                yazi = "";
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var messagelist = mm.GetListSendBoxSearch(s, yazi).Where(x => x.MessageDraftStatus == true && x.MessageStatus == true).ToList().ToPagedList(p, 10);
                return View(messagelist);
            }
            else
            {
                Context c = new Context();
                s = (string)Session["WriterMail"];
                var messagelist = mm.GetListSendBoxSearch(s,yazi).Where(x => x.MessageDraftStatus == true && x.MessageStatus == true).ToList().ToPagedList(p, 10);
                return View(messagelist);
            }
            
        }
        //Mesaj Detayları
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messagelist = mm.GetById(id);
            messagelist.MessageInboxIsRead = true;
            mm.MessageUpdate(messagelist);
            return View(messagelist);
        }

        //Gönderilen Mesaj Detayları
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messagelist = mm.GetById(id);
            return View(messagelist);
        }
        //Taslak GÖnderme
        [HttpGet]
        public ActionResult MessageSendDraft(int id)
        {
            var messagelist = mm.GetById(id);
            return View(messagelist);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MessageSendDraft(Message p, string parameter)
        {
            MessageValidator mv = new MessageValidator();
            ValidationResult vr = mv.Validate(p);
            if (vr.IsValid)
            {
                if (parameter == "send")
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.MessageSenderMail = (string)Session["WriterMail"];
                    p.MessageDraftStatus = false;
                    p.MessageStatus = true;
                    mm.MessageUpdate(p);
                    return RedirectToAction("Sendbox");
                }
            }
            else
            {
                foreach (var item in vr.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //çöp kutusu
        public ActionResult DeleteBoxResult(string s, string yazi = "", int ses = 0, int p = 1)
        {
            if (ses == 1)
            {
                yazi = "";
                Context c = new Context();
                s = (string)Session["WriterMail"];
                ViewBag.usermail = s;
                var messagelist = mm.GetListDeleteBoxSearch(s, yazi).ToPagedList(p, 10);
                return View(messagelist);
            }
            else
            {
                Context c = new Context();
                s = (string)Session["WriterMail"];
                ViewBag.usermail = s;
                var messagelist = mm.GetListDeleteBoxSearch(s, yazi).Where(x => x.MessageStatus == false && x.MessageDraftStatus == false).ToList().ToPagedList(p, 10);
                return View(messagelist);
            }
        }

        [HttpPost]
        public ActionResult DeleteDrafts(int[] selectedDrafts)
        {
            foreach (int id in selectedDrafts)
            {
                var deletedraft = mm.GetById(id);
                deletedraft.MessageDraftStatus = false;
                deletedraft.MessageStatus = false;
                mm.MessageUpdate(deletedraft);
            }
            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult DeleteDraftsEnd(int[] selectedDrafts)
        {
            foreach (int id in selectedDrafts)
            {
                var deletedraft = mm.GetById(id);
                deletedraft.MessageDraftStatus = false;
                deletedraft.MessageStatus = false;
                deletedraft.MessageDeleteStatus = true;
                mm.MessageUpdate(deletedraft);
            }
            return Json(new { success = true });
        }
    }
}