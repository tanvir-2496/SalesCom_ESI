using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class SalesChannelTargetViewModel
    {
        public int sales_channel_id { get; set; }
        public string sales_channel_name { get; set; }
        public int report_cycle_id { get; set; }
        public int quarter { get; set; }
        public int year { get; set; }

        
        public SalesChannelTargetViewModel() { }

        public SalesChannelTargetViewModel(DataRow dr)
        {
            if (dr["SALES_CHANNEL_ID"] != DBNull.Value) { this.sales_channel_id = Convert.ToInt32(dr["SALES_CHANNEL_ID"]); }
            
            if (dr["REPORT_CYCLE_ID"] != DBNull.Value) this.report_cycle_id = Convert.ToInt32(dr["REPORT_CYCLE_ID"]);
            if (dr["QUARTER"] != DBNull.Value) this.quarter = Convert.ToInt32(dr["QUARTER"]);
            if (dr["YEAR"] != DBNull.Value) this.year = Convert.ToInt32(dr["YEAR"]);

            this.sales_channel_name = dr["sales_channel_name"] as String;
           
        }
    }
}
