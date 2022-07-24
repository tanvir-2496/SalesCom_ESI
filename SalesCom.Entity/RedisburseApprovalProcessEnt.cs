using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class RedisburseApprovalProcessEnt
    {
        public int redisburse_id {get; set;} 
        public int report_cycle_id {get; set;}  
        public int  flow_id {get; set;}  
        public int  current_level_id {get; set;}  
        public int  current_order_id {get; set;}  
        public string reportname {get; set;}  
        public string report_duration {get; set;}  
        public int current_redisburse_number {get; set;}  
        public string claim_amt {get; set;}  
        public string withheld_amt {get; set;}  
        public string disburse_amt {get; set;}  
        public string curr_disburse_amt {get; set;}
        public string approvallevelname { get; set; }

        public RedisburseApprovalProcessEnt() { }

        public RedisburseApprovalProcessEnt(DataRow dr)
        {
            if (dr["redisburse_id"] != DBNull.Value) { this.redisburse_id = Convert.ToInt32(dr["redisburse_id"]); }
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            if (dr["flow_id"] != DBNull.Value) { this.flow_id = Convert.ToInt32(dr["flow_id"]); }
            if (dr["current_level_id"] != DBNull.Value) { this.current_level_id = Convert.ToInt32(dr["current_level_id"]); }
            if (dr["current_order_id"] != DBNull.Value) { this.current_order_id = Convert.ToInt32(dr["current_order_id"]); }
            this.reportname = dr["reportname"] as String;
            this.report_duration = dr["report_duration"] as String;
            if (dr["current_redisburse_number"] != DBNull.Value) { this.current_redisburse_number = Convert.ToInt32(dr["current_redisburse_number"]); }
            this.claim_amt = dr["claim_amt"] as String;
            this.withheld_amt = dr["withheld_amt"] as String;
            this.disburse_amt = dr["disburse_amt"] as String;
            this.curr_disburse_amt = dr["curr_disburse_amt"] as String;
            this.approvallevelname = dr["approvallevelname"] as String;
        }
    }
}
