using System;
using System.Data;
using System.Globalization;

namespace SalesManager.Common.DataTableHelpers
{
    public class DataTableBuilder : IDataTableBuilder
    {
        public void ConvertColumnType(DataTable dt, string columnName, Type newType)
        {
            using (DataColumn dc = new DataColumn(columnName + "_new", newType))
            {                
                int ordinal = dt.Columns[columnName].Ordinal;
                dt.Columns.Add(dc);
                dc.SetOrdinal(ordinal);
               
                foreach (DataRow dr in dt.Rows)
                    dr[dc.ColumnName] = Convert.ChangeType(dr[columnName], newType, CultureInfo.InvariantCulture);
             
                dt.Columns.Remove(columnName);
               
                dc.ColumnName = columnName;
            }
        }
    }
}
