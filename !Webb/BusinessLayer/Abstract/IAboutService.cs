using EntityLayer.Concreate;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        List<About> GetListSearch(string yazi);
        void AboutAdd(About about);
        About GetById(int id);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}