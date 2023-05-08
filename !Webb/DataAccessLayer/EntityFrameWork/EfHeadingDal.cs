using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repostories;
using EntityLayer.Concreate;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfHeadingDal:GenericRepostory<Heading>,IHeadingDal
    {
    }
}
