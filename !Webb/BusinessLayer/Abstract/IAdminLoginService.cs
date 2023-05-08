using EntityLayer.Concreate;

namespace BusinessLayer.Abstract
{
    public interface IAdminLoginService
    {
        Admin GetAdminLogin(string username, string password);
    }
}