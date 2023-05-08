using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class ContactMenager:IContactService
    {
        private IContactDal _contact;

        public ContactMenager(IContactDal contact)
        {
            _contact= contact;
        }

        public List<Contact> GetList()
        {
           return _contact.List();
        }

        public List<Contact> GetListSearch(string yazi)
        {
            return _contact.List(x => x.ContactMail.Contains(yazi)&& x.ContactStatus == true);
        }

        public List<Contact> GetListDeleteSearch(string yazi)
        {
            return _contact.List(x => x.ContactMail.Contains(yazi) && x.ContactStatus == false&&x.ContactStatusEnd==false);
        }

        public void ContactAdd(Contact contact)
        {
            _contact.Insert(contact);
        }

        public Contact GetById(int id)
        {
            return _contact.Get(x => x.ContactID == id);
        }

        public void ContactDelete(Contact contact)
        {
           _contact.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
           _contact.Update(contact);
        }
    }
}