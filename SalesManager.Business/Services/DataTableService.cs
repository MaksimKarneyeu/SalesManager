using SalesManager.Common.DataTableHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Business.Services
{
    public class DataTableService : IDataTableService
    {
        private IDataTableBuilder dataTableBuilder;

        public DataTableService(IDataTableBuilder dataTableBuilder)
        {
            this.dataTableBuilder = dataTableBuilder;
        }

        public DataTable ConverSaleColumnTypes(DataTable dt)
        {
            this.dataTableBuilder.ConvertColumnType(dt, "Order Date", typeof(DateTime));
            this.dataTableBuilder.ConvertColumnType(dt, "Ship Date", typeof(DateTime));
            this.dataTableBuilder.ConvertColumnType(dt, "Unit Price", typeof(double));
            this.dataTableBuilder.ConvertColumnType(dt, "Unit Cost", typeof(double));
            this.dataTableBuilder.ConvertColumnType(dt, "Total Revenue", typeof(double));
            this.dataTableBuilder.ConvertColumnType(dt, "Total Cost", typeof(double));
            this.dataTableBuilder.ConvertColumnType(dt, "Total Profit", typeof(double));
            return dt;
        }
    }
}
