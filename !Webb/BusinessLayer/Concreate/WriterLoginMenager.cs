using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class WriterLoginMenager:IWriterLoginService
    {
        private IWriterDal _writer;

        public WriterLoginMenager(IWriterDal writer)
        {
            _writer=writer;
        }
        public Writer GetWriter(string username, string password)
        {
            return _writer.Get(x => x.WriterMail == username && x.WriterPassword == password);
        }
    }
}