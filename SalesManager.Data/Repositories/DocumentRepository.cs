using SalesManager.Data.Context;
using SalesManager.Data.Entities;

namespace SalesManager.Data.Repositories
{
    public class DocumentRepository : Repository<Document>
    {
        public DocumentRepository(SalesManagerContext context) : base(context) { }
    }
}
