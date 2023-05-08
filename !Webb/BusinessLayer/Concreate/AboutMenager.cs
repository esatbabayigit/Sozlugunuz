using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class AboutMenager:IAboutService
    {
        private IAboutDal _about;

        public AboutMenager(IAboutDal about)
        {
            _about=about;
        }
        public List<About> GetList()
        {
            return _about.List();
        }

        public List<About> GetListSearch(string yazi)
        {
            return _about.List(x => x.AboutDetails1.Contains(yazi));
        }

        public void AboutAdd(About about)
        {
            _about.Insert(about);
        }

        public About GetById(int id)
        {
            return _about.Get(x => x.AboutId == id);
        }

        public void AboutDelete(About about)
        {
            _about.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _about.Update(about);
        }
    }
}