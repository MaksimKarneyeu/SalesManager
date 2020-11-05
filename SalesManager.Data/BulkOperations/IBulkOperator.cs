using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Data.BulkOperations
{
    public interface IBulkOperator
    {
        void BulkInsert(DataTable dt, Guid DocumentID);
        void BulkUpdate(DataTable dt, Guid DocumentID);
    }
}
