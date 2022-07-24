using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class HeadWiseWithheldListEnt
    {
        public int row_number { get; set; }
        public int report_cycle_id { get; set; }
        public string reportname { get; set; }
        public string commission_month { get; set; }
        public string publish_month { get; set; }
        public string report_duration { get; set; }
        public string withheld_amount { get; set; }
        public int record_count { get; set; }

        public HeadWiseWithheldListEnt() { }

        public HeadWiseWithheldListEnt(DataRow dr)
        {
            if (dr["row_number"] != DBNull.Value) { this.row_number = Convert.ToInt32(dr["row_number"]); }
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            this.reportname = dr["reportname"] as string;
            this.commission_month = dr["commission_month"] as string;
            this.publish_month = dr["publish_month"] as string;
            this.report_duration = dr["report_duration"] as string;
            this.withheld_amount = dr["withheld_amount"] as string;
            if (dr["record_count"] != DBNull.Value) { this.record_count = Convert.ToInt32(dr["record_count"]); }
        }
    }
}
