using DocumentManagement.Domain.Models;

namespace DocumentManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetByLogin(string login);
        User Create(User user);
    }
}
