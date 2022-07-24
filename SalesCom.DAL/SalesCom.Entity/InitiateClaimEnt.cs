using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class InitiateClaimEnt
    {
       public int report_cycle_id {get; set;}
       public int flow_id { get; set; }
       public Int16 order_id { get; set; }
       public int report_id { get; set; }
       public int report_type_id { get; set; } 
       public string report_name {get; set;}
       public string report_duration {get; set;}
       public string commission_amount {get; set;}
       public Int16 status { get; set; }
       public string current_status { get; set; }

       public InitiateClaimEnt() 
       { 
       
       }

       public InitiateClaimEnt(DataRow dr)
       {
           if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
           if (dr["flow_id"] != DBNull.Value) { this.flow_id = Convert.ToInt32(dr["flow_id"]); }
           if (dr["order_id"] != DBNull.Value) { this.order_id = Convert.ToInt16(dr["order_id"]); }
           if (dr["report_id"] != DBNull.Value) { this.report_id = Convert.ToInt32(dr["report_id"]); }
           if (dr["report_type_id"] != DBNull.Value) { this.report_type_id = Convert.ToInt32(dr["report_type_id"]); }
           this.report_name = dr["report_name"] as String;
           this.report_duration = dr["report_duration"] as String;
           this.commission_amount = dr["commission_amount"] as String;
           if (dr["status"] != DBNull.Value) { this.status = Convert.ToInt16(dr["status"]); }
           this.current_status = dr["current_status"] as String;
       }

    }
}
