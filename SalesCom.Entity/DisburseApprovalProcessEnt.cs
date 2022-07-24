using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class DisburseApprovalProcessEnt
    {
        public int Id { get; set; }
        public int report_cycle_id { get; set; }
        public string reportname { get; set; }
        public Int16 level_id { get; set; }
        public Int16 flow_id { get; set; }
        public Int16 orderid { get; set; }
        public string level_name { get; set; }
        public string current_status { get; set; }
        public string report_duration { get; set; }
        public string claim_amt { get; set; }
        public string withheld_amt { get; set; } 
        public string disburse_amt { get; set; }

        public DisburseApprovalProcessEnt()
        {
        }

        public DisburseApprovalProcessEnt(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            this.reportname = dr["reportname"] as String;
            if (dr["level_id"] != DBNull.Value) { this.level_id = Convert.ToInt16(dr["level_id"]); }
            if (dr["flow_id"] != DBNull.Value) { this.flow_id = Convert.ToInt16(dr["flow_id"]); }
            if (dr["orderid"] != DBNull.Value) { this.orderid = Convert.ToInt16(dr["orderid"]); }
            this.level_name = dr["level_name"] as String;
            this.current_status = dr["current_status"] as String;
            this.report_duration = dr["report_duration"] as String;
            this.claim_amt = dr["claim_amt"] as String;
            this.withheld_amt = dr["withheld_amt"] as String;
            this.disburse_amt = dr["disburse_amt"] as String;
        }
    }
}
