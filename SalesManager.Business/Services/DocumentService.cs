using SalesManager.Data.Entities;
using SalesManager.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManager.Business.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository<Document> documentRepository;
        public DocumentService(IRepository<Document> documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public async Task<ICollection<Document>> GetDocumentsAsync()
        {
            try
            {
                return await documentRepository.GetAllAsync();
            }
            catch (System.Exception)
            {
                throw;
            }            
        }
    }
}
