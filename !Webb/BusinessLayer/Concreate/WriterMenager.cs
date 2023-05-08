using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class WriterMenager:IWriterService
    {
        private IWriterDal _writer;

        public WriterMenager(IWriterDal writer)
        {
            _writer = writer;
        }

        public List<Writer> GetList()
        {
            return _writer.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writer.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writer.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writer.Update(writer);
        }

        

        public Writer GetById(int id)
        {
            return _writer.Get(x => x.WriterID == id);
        }

        public List<Writer> GetListByWriterId(int id)
        {
            return _writer.List(x => x.WriterID == id);
        }
    }
}