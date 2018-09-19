using AutoMapper;
using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces;
using DocumentManagement.Domain.Interfaces;
using DocumentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentManagement.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IUserService _userService;
        private readonly IDocumentStorage _documentStorage;

        public DocumentService(IDocumentRepository documentRepository,
                               IUserService userService,
                               IDocumentStorage documentStorage)
        {
            _documentRepository = documentRepository;
            _userService = userService;
            _documentStorage = documentStorage;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public long Create(Document document, string username)
        {
            var user = _userService.GetOrCreateUser(username);
            document.IdUser = user.Id;

            document.FileNameStored = _documentStorage.Store(document.Name, document.ContentBase64);

            return _documentRepository.Create(document);
        }

        public void Delete(long id)
        {
            var document = _documentRepository.GetById(id);
            if (document != null)
            {
                _documentStorage.Delete(document.FileNameStored);
                _documentRepository.Delete(document);
             }
        }

        public IEnumerable<DocumentDTO> List() =>
            _documentRepository.List().Select(d =>
            {
                var dto = Mapper.Map<DocumentDTO>(d);
                dto.ContentBase64 = _documentStorage.GetBase64(d.FileNameStored);
                return dto;
            });

        public void UpdateAccessDate(long id) =>
            _documentRepository.UpdateAccessDate(id);
    }
}