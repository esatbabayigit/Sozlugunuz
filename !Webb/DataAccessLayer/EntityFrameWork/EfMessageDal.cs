using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repostories;
using EntityLayer.Concreate;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfMessageDal:GenericRepostory<Message>,IMessageDal
    {
        
    }
}