using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class kpi_approval_ent
    {
        public int sales_group_id { get; set; }
        public int sales_channel_id { get; set; }
        public int approval_status_id { get; set; }
        public string report_name { get; set; }
        public string current_level { get; set; }
        public int report_cycle_id { get; set; }
        public int order_id { get; set; }
        public int approvallevel_id { get; set; }
        public int current_level_id { get; set; }
        public int report_type { get; set; }
        public int month { get; set; }

        public kpi_approval_ent()
        {

        }

        public kpi_approval_ent(DataRow dr)
        {
            if (dr["sales_group_id"] != DBNull.Value) { this.sales_group_id = Convert.ToInt32(dr["sales_group_id"]); }
            if (dr["sales_channel_id"] != DBNull.Value) { this.sales_channel_id = Convert.ToInt32(dr["sales_channel_id"]); }
            if (dr["approval_status_id"] != DBNull.Value) { this.approval_status_id = Convert.ToInt32(dr["approval_status_id"]); }
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            if (dr["order_id"] != DBNull.Value) { this.order_id = Convert.ToInt32(dr["order_id"]); }
            if (dr["approvallevel_id"] != DBNull.Value) { this.approvallevel_id = Convert.ToInt32(dr["approvallevel_id"]); }
            if (dr["current_level_id"] != DBNull.Value) { this.current_level_id = Convert.ToInt32(dr["current_level_id"]); }
            if (dr["report_type"] != DBNull.Value) { this.report_type = Convert.ToInt32(dr["report_type"]); }
            if (dr["month"] != DBNull.Value) { this.month = Convert.ToInt32(dr["month"]); }

            this.current_level = dr["current_level"] as String;
            this.report_name = dr["report_name"] as String;

        }
    }
}
