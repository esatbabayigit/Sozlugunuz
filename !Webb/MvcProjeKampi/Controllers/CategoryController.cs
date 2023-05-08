using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concreate;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private CategoryManager mn = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = mn.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult GetCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCategoryAdd(Category p)
        {
            CategoryValidator categoryValidator= new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                mn.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
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
    }
}