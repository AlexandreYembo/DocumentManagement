using AutoMapper;
using DocumentManagement.Application.DTOs;
using DocumentManagement.Domain.Models;

namespace DocumentManagement.Application.AutoMapper.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentDTO>();
            CreateMap<DocumentDTO, Document>();
        }
    }
}