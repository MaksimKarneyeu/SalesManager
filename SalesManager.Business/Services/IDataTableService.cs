using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Business.Services
{
    public interface IDataTableService
    {
        DataTable ConverSaleColumnTypes(DataTable at);
    }
}
