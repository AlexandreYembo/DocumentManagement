using DocumentManagement.Domain.Models;
using System;

namespace DocumentManagement.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        bool ValidateLogin(string login);
        User GetOrCreateUser(string username);
    }
}
