using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace SalesManager.Data.BulkOperations
{
    public class DocumentBulkOperator : BaseBulkOperator
    {
        public override void BulkInsert(DataTable dt, Guid DocumentID)
        {
            PerformOperation(x =>
            {
                var bulk = new BulkOperation(x);
                bulk.DestinationTableName = "Sales";
                AddCollumn(dt, "ID", DocumentID);
                bulk.ColumnMappings.Add("ID", ColumnMappingDirectionType.Output);                
                AddCollumn(dt, "DocumentID", DocumentID);
                MapColumns(bulk);                
                bulk.BulkInsert(dt);
            });
        }

        public override void BulkUpdate(DataTable dt, Guid DocumentID)
        {
            PerformOperation(x =>
            {
                var bulk = new BulkOperation(x);
                bulk.DestinationTableName = "Sales";
                AddCollumn(dt, "ID", DocumentID);
                bulk.ColumnMappings.Add("ID", true);
                MapColumns(bulk);
                DataColumn newColumn = new DataColumn("DocumentID", typeof(Guid));
                newColumn.DefaultValue = DocumentID;
                dt.Columns.Add(newColumn);
                bulk.InsertIfNotExists = true;                
                bulk.BulkUpdate(dt);
            });
        }

        private void AddCollumn(DataTable dt, string collumnName,  Guid DocumentID)
        {
            DataColumn newColumn = new DataColumn(collumnName, typeof(Guid));
            newColumn.DefaultValue = DocumentID;
            dt.Columns.Add(newColumn);            
        }

        private void MapColumns(BulkOperation bulk)
        {
           
            bulk.ColumnMappings.Add("Region");
            bulk.ColumnMappings.Add("Country");            
            bulk.ColumnMappings.Add("Item Type", "ItemType");
            bulk.ColumnMappings.Add("Sales Channel", "SalesChannel");
            bulk.ColumnMappings.Add("Order Priority", "OrderPriority");
            bulk.ColumnMappings.Add("Order Date", "OrderDate");
            bulk.ColumnMappings.Add("Order ID", "OrderID");
            bulk.ColumnMappings.Add("Ship Date", "ShipDate");
            bulk.ColumnMappings.Add("Units Sold", "UnitsSold");
            bulk.ColumnMappings.Add("Unit Price", "UnitPrice");
            bulk.ColumnMappings.Add("Unit Cost", "UnitCost");
            bulk.ColumnMappings.Add("Total Revenue", "TotalRevenue");
            bulk.ColumnMappings.Add("Total Cost", "TotalCost");
            bulk.ColumnMappings.Add("Total Profit", "TotalProfit");
            bulk.ColumnMappings.Add("DocumentID");
        }
    }
}
