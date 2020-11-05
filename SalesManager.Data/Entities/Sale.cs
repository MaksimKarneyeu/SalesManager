using System;

namespace SalesManager.Data.Entities
{
    public class Sale : BaseEntity
    {
        public string Region { get; set; }
        public string Country { get; set; }
        public string ItemType { get; set; }
        public string SalesChannel { get; set; }
        public string OrderPriority { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderID { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? UnitsSold { get; set; }
        public double? UnitPrice { get; set; }
        public double? UnitCost { get; set; }
        public double? TotalRevenue { get; set; }
        public double? TotalCost { get; set; }
        public double? TotalProfit { get; set; }

        public Guid? DocumentID { get; set; }

        public Document Document { get; set; }
    }
}
