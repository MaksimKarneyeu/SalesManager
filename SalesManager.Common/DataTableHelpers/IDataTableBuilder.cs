using System;
using System.Data;

namespace SalesManager.Common.DataTableHelpers
{
    public interface IDataTableBuilder
    {
        void ConvertColumnType(DataTable dt, string columnName, Type newType);
    }
}
