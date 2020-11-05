using SalesManager.Data.Context;
using SalesManager.Data.Entities;

namespace SalesManager.Data.Repositories
{
    public class SaleRepository : Repository<Sale>
    {
        public SaleRepository(SalesManagerContext context) : base(context) { }

    }
}
