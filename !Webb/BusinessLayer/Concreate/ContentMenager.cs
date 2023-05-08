using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class ContentMenager : IContentService
    {
        private IContentDal _content;

        public ContentMenager(IContentDal content)
        {
            _content = content;
        }

        public List<Content> GetList()
        {
            return _content.List();
        }

        public List<Content> GetListSearch(string p)
        {
            return _content.List(x => x.ContentValue.Contains(p));
        }

        public List<Content> GetListByWriter(int id, string yazi)
        {
            return _content.List(x => x.WriterID == id&&x.ContentValue.Contains(yazi));
        }

        public List<Content> GetListByWriterPrivateContent(int id,int? headid, string yazi)
        {
            return _content.List(x => x.WriterID == id&&x.HeadingID==headid&&x.ContentValue.Contains(yazi));
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _content.List(x => x.HeadingID == id);
        }


        public void ContentAdd(Content content)
        {
            _content.Insert(content);
        }

        public Content GetById(int id)
        {
            return _content.Get(x => x.ContentID == id);
        }

        public void ContentDelete(Content content)
        {
            _content.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _content.Update(content);
        }
    }
}