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
            CreateMap<DocumentDTO, Document>()
                .ForMember(x => x.FileNameStored, p => p.Ignore())
                .ForMember(x => x.User, p => p.Ignore())
                .ForMember(x => x.IdUser, p => p.Ignore());
            CreateMap<DocumentInsertDTO, Document>()
                .ForMember(x => x.Id, p => p.Ignore())
                .ForMember(x => x.FileNameStored, p => p.Ignore())
                .ForMember(x => x.UploadDate, p => p.Ignore())
                .ForMember(x => x.UpdateDate, p => p.Ignore())
                .ForMember(x => x.LastAccessDate, p => p.Ignore())
                .ForMember(x => x.IdUser, p => p.Ignore())
                .ForMember(x => x.User, p => p.Ignore());
        }
    }
}