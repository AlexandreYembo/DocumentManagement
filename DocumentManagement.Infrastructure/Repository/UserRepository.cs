using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
