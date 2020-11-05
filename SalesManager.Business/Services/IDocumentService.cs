using SalesManager.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManager.Business.Services
{
    public interface IDocumentService
    {
        Task<ICollection<Document>> GetDocumentsAsync();
    }
}
