using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class AdminCategoryControllerController : Controller
    {
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles ="A")]
        public ActionResult Index(int p =1)
        {
            var categoryvalues = cm.GetList().ToPagedList(p,10);
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalues = cm.GetById(id);
            cm.CategoryDelete(categoryvalues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            
           cm.CategoryUpdate(p);
           return RedirectToAction("Index");
        }


        public ActionResult TodoList()
        {
            return View();
        }
    }
}