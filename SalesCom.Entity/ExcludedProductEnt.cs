using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ExcludedProductEnt
    {
        public int ExcludedProductId { get; set; }
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public ExcludedProductEnt() { }

        public ExcludedProductEnt(DataRow dr)
        {
            if (dr["ExcludedProductId"] != DBNull.Value) { this.ExcludedProductId = Convert.ToInt32(dr["ExcludedProductId"]); }
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            this.ReportName = dr["ReportName"] as String;

            if (dr["ProductId"] != DBNull.Value) { this.ProductId = Convert.ToInt32(dr["ProductId"]); }
            this.ProductCode = dr["ProductCode"] as String;
            this.ProductName = dr["ProductName"] as String;
        }
    }
}
