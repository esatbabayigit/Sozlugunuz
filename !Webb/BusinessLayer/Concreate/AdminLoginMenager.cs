using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class AdminLoginMenager : IAdminLoginService
    {
        private IAdminDal _admin;

        public AdminLoginMenager(IAdminDal admin)
        {
            _admin = admin;
        }
        public Admin GetAdminLogin(string username, string password)
        {
            return _admin.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }
    }
}