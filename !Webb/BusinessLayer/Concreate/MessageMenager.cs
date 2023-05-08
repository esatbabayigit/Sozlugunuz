using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class MessageMenager:IMessageService
    {
        private IMessageDal _message;

        public MessageMenager(IMessageDal message)
        {
            _message=message;
        }

        public List<Message> GetListInbox(string mail)
        {
            return _message.List(x=>x.MessageReceiverMail == mail);
        }

        public List<Message> GetListSendBox(string mail)
        {
            return _message.List(x => x.MessageSenderMail == mail);
        }

        public List<Message> GetListSendBoxSearch(string mail, string yazi)
        {
            return _message.List(x=>x.MessageSenderMail==mail&&x.MessageReceiverMail.Contains(yazi) );
        }

        public List<Message> GetListDraftBox(string mail)
        {
            return _message.List(x => x.MessageDraftStatus == true&&x.MessageSenderMail==mail);
        }

        public List<Message> GetListDraftBoxSearch(string mail, string yazi)
        {
            throw new System.NotImplementedException();
        }

        public List<Message> GetListDeleteBoxSearch(string mail, string yazi)
        {
            return _message.List(x => x.MessageStatus == false && x.MessageDraftStatus == false&&(x.MessageReceiverMail==mail||x.MessageSenderMail==mail)&&(x.MessageReceiverMail.Contains(yazi)|| x.MessageSenderMail.Contains(yazi))&&x.MessageDeleteStatus==false);
        }

        public List<Message> GetListSearch(string p,string mail)
        {
            return _message.List(x => x.MessageSenderMail.Contains(p)&&x.MessageReceiverMail==mail&&x.MessageStatus==true);
        }

        public List<Message> GetListDeleteBox()
        {
            throw new System.NotImplementedException();
        }

        public void MessageAdd(Message message)
        {
            _message.Insert(message);
        }

        public Message GetById(int id)
        {
           return _message.Get(x => x.MessageID == id);
        }

        public void MessageDelete(Message message)
        {
            _message.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _message.Update(message);
        }
    }
}