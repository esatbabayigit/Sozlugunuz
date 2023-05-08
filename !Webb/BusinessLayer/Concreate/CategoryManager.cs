using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repostories;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class CategoryManager : ICategoryService
    {

      
        private ICategoryDal _category;

        public CategoryManager(ICategoryDal category)
        {
            _category = category;
        }

        public List<Category> GetListChart()
        {
            return _category.List();
        }

        public void CategoryAdd(Category category)
        {
            _category.Insert(category);
        }

        public Category GetById(int id)
        {
            return _category.Get(x => x.CategoryID == id);
        }

        public void CategoryDelete(Category category)
        {
            _category.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _category.Update(category);
        }

        public List<Category> GetList()
        {
            return _category.List();
        }
    }
}
