using System;
using System.Data;

namespace SalesCom.Entity
{
    public class ReportTypeEnt
    {
        public int report_type_id { get; set; }
        public string report_type_name { get; set; }

        public ReportTypeEnt() { }

        public ReportTypeEnt(DataRow dr)
        {
            if (dr["report_type_id"] != DBNull.Value) { this.report_type_id = Convert.ToInt32(dr["report_type_id"]); }
            this.report_type_name = dr["report_type_name"] as String;
        }
    }
}
