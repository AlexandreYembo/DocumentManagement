using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Domain.Models;
using DocumentManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User GetByLogin(string username) =>
            _dbContext.Users.FirstOrDefault(u => u.Login == username);
    }
}