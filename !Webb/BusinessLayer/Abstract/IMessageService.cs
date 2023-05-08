using EntityLayer.Concreate;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string mail);//burayı düzelt searchden düzelt aşşağıdaki propla yapsın arama işlemini
        List<Message> GetListSendBox(string mail);
        List<Message> GetListSendBoxSearch(string mail,string yazi);
        List<Message> GetListDraftBox(string mail);
        List<Message> GetListDraftBoxSearch(string mail,string yazi);
        List<Message> GetListDeleteBoxSearch(string mail,string yazi);
        List<Message> GetListSearch(string p,string mail);
        List<Message> GetListDeleteBox();
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}