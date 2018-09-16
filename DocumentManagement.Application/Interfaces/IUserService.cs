using System;

namespace DocumentManagement.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        bool ValidateLogin(string login);
    }
}
