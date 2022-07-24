using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportWiseWithheldListEnt
    {
        public int row_number { get; set; }
        public int report_cycle_id { get; set; }
        public string reportname { get; set; }
        public string report_duration { get; set; }
        public string claim_amt { get; set; }
        public string withheld_amt_ch { get; set; }
        public decimal  withheld_amt { get; set; }
        public string disburse_amt { get; set; }
        public int record_count { get; set; }
        public string commissiom_cycle { get; set; }
        public int disburse_approval_flowid { get; set; }
        public int current_redisburse_number { get; set; }
        public int current_order_id { get; set; }
        public decimal current_redisbure_amount { get; set; }
        public string current_redisbure_amount_ch { get; set; }
        public string approvallevelname { get; set; }



        public ReportWiseWithheldListEnt() { }

        public ReportWiseWithheldListEnt(DataRow dr)
        {
            if (dr["row_number"] != DBNull.Value) { this.row_number = Convert.ToInt32(dr["row_number"]); }
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            this.reportname = dr["reportname"] as string;
            this.report_duration = dr["report_duration"] as string;
            this.claim_amt = dr["claim_amt"] as string;
            this.withheld_amt_ch = dr["withheld_amt_ch"] as string;
            if (dr["withheld_amt"] != DBNull.Value) { this.withheld_amt = Convert.ToDecimal(dr["withheld_amt"]); }
            this.disburse_amt = dr["disburse_amt"] as string;
            if (dr["record_count"] != DBNull.Value) { this.record_count = Convert.ToInt32(dr["record_count"]); }
            this.commissiom_cycle = dr["commissiom_cycle"] as string;
            if (dr["disburse_approval_flowid"] != DBNull.Value) { this.disburse_approval_flowid = Convert.ToInt32(dr["disburse_approval_flowid"]); }
            if (dr["current_redisburse_number"] != DBNull.Value) { this.current_redisburse_number = Convert.ToInt32(dr["current_redisburse_number"]); }
            if (dr["current_order_id"] != DBNull.Value) { this.current_order_id = Convert.ToInt32(dr["current_order_id"]); }
            if (dr["current_redisbure_amount"] != DBNull.Value) { this.current_redisbure_amount = Convert.ToDecimal(dr["current_redisbure_amount"]); }
            this.current_redisbure_amount_ch = dr["current_redisbure_amount_ch"] as string;
            this.approvallevelname = dr["approvallevelname"] as string;
        }
    }
}
