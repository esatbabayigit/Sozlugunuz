using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class AdminMenager : IAdminService
    {
        private IAdminDal _admin;

        public AdminMenager(IAdminDal admin)
        {
            _admin = admin;
        }

        public List<Admin> GetList()
        {
            return _admin.List();
        }

        public void AdminAdd(Admin admin)
        {
            _admin.Insert(admin);
        }

        public Admin GetById(int id)
        {
            return _admin.Get(x => x.AdminId == id);
        }

        public void AdminDelete(Admin admin)
        {
            _admin.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _admin.Update(admin);
        }
    }
}