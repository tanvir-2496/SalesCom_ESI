using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class commission_approval_ent
    {
        public int id { get; set; }
        public Int16 flow_id { get; set; }
        public Int16 claim_flow_id { get; set; }
        public Int16 level_id { get; set; }
        public Int16 order_id { get; set; }
        public int report_cycle_id { get; set; }
        public int report_id { get; set; }
        public string file_type { get; set; }
        public string report_name { get; set; }
        public string base_moth { get; set; }
        public string publish_month { get; set; }
        public string current_level { get; set; }
        public string com_amount { get; set; }
        public string comments { get; set; }
     

        public commission_approval_ent()
        {

        }

        public commission_approval_ent(DataRow dr)
        {
            if (dr["id"] != DBNull.Value) { this.id = Convert.ToInt32(dr["id"]); }
            if (dr["flow_id"] != DBNull.Value) { this.flow_id = Convert.ToInt16(dr["flow_id"]); }
            if (dr["claim_flow_id"] != DBNull.Value) { this.claim_flow_id = Convert.ToInt16(dr["claim_flow_id"]); }
            if (dr["level_id"] != DBNull.Value) { this.level_id = Convert.ToInt16(dr["level_id"]); }
            if (dr["order_id"] != DBNull.Value) { this.order_id = Convert.ToInt16(dr["order_id"]); }
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            if (dr["report_id"] != DBNull.Value) { this.report_id = Convert.ToInt32(dr["report_id"]); }
            this.file_type = dr["file_type"] as String;
            this.report_name = dr["report_name"] as String;
            this.base_moth = dr["base_moth"] as String;
            this.publish_month = dr["publish_month"] as String;
            this.current_level = dr["current_level"] as String;
            this.com_amount = dr["com_amount"] as String;
            this.comments = dr["comments"] as String;

        }
    }

}
