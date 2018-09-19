namespace DocumentManagement.Domain.Interfaces
{
    public interface IDocumentStorage
    {
        string Store(string name, string content);
        string GetBase64(string fileNameStored);
        void Delete(string fileNameStored);
    }
}
