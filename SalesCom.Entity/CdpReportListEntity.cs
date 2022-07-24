using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
   public class CdpReportListEntity
    {
        public Int32 cdp_report_info_id { get; set; }
        public string report_name { get; set; }


        public CdpReportListEntity() { }

        public CdpReportListEntity(DataRow dr)
        {

            if (dr["cdp_report_info_id"] != DBNull.Value) { this.cdp_report_info_id = Convert.ToInt32(dr["cdp_report_info_id"]); }
            this.report_name = dr["report_name"] as String;

        }
    }
}
