using DocumentManagement.Application.Interfaces;
using DocumentManagement.Domain.Interfaces;
using System;

namespace DocumentManagement.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUserRepository _userRepository;

        public DocumentService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateLogin(string login)
        {
            return _userRepository.GetByLogin(login) != null;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}