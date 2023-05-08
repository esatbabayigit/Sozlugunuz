using EntityLayer.Concreate;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListSearch(string yazi);
        List<Heading> GetListByWriter(int id);
        List<Heading> GetListByWriterSearch(int id,string yazi);
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}