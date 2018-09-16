using DocumentManagement.Application.Interfaces;
using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Domain.Models;
using System;

namespace DocumentManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateLogin(string username)
        {
            return _userRepository.GetByLogin(username) != null;
        }

        public User GetOrCreateUser(string username)
        {
            var user = _userRepository.GetByLogin(username);

            if (user == null)
            {
                user = new User { Login = username };
                return _userRepository.Create(user);
            }
            return user;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}