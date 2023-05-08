using System;
using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class HeadingMenager:IHeadingService
    {
        private IHeadingDal _heading;

        public HeadingMenager(IHeadingDal heading)
        {
            _heading=heading;
        }

        public List<Heading> GetList()
        {
            return _heading.List();
        }

        public List<Heading> GetListSearch(string yazi)
        {
            return _heading.List(x => x.HeadingName.Contains(yazi));
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _heading.List(x => x.WriterID == id);
        }

        public List<Heading> GetListByWriterSearch(int id, string yazi)
        {
            return _heading.List(x => x.WriterID == id && x.HeadingName.Contains(yazi));
        }


        public Heading GetById(int id)
        {
            return _heading.Get(x => x.HeadingID == id);
        }

        public void HeadingDelete(Heading heading)
        {
            
            _heading.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _heading.Update(heading);
        }

        public void HeadingAdd(Heading p)
        {
            _heading.Insert(p);
        }
    }
}