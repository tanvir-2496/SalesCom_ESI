using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ClaimApprovalProcessEnt
    {
        public int Id { get; set; }
        public int report_cycle_id {get; set;} 
        public string reportname {get; set;}  
        public string report_duration {get; set;}
        public string level_name { get; set; } 
        public Int16 level_id {get; set;} 
        public Int16 flow_id {get; set;} 
        public Int16 disburse_flow_id {get; set;}  
        public Int16 orderid {get; set;}  
        public string current_status {get; set;}  
        public string report_amt {get; set;}  
        public string discard_amt {get; set;}
        public string claim_amt { get; set; }

        public ClaimApprovalProcessEnt()
        {
        }

        public ClaimApprovalProcessEnt(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            this.reportname = dr["reportname"] as String;
            this.report_duration = dr["report_duration"] as String;
            this.level_name = dr["level_name"] as String;
            if (dr["level_id"] != DBNull.Value) { this.level_id = Convert.ToInt16(dr["level_id"]); }
            if (dr["flow_id"] != DBNull.Value) { this.flow_id = Convert.ToInt16(dr["flow_id"]); }
            if (dr["disburse_flow_id"] != DBNull.Value) { this.disburse_flow_id = Convert.ToInt16(dr["disburse_flow_id"]); }
            if (dr["orderid"] != DBNull.Value) { this.orderid = Convert.ToInt16(dr["orderid"]); }
            this.current_status = dr["current_status"] as String;
            this.report_amt = dr["report_amt"] as String;
            this.discard_amt = dr["discard_amt"] as String;
            this.claim_amt = dr["claim_amt"] as String;
        }
    }
}
