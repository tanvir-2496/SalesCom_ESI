using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportApprovalEnt
    {
        public Int32 report_approval_id { get; set; }
        public string report_name { get; set; }
        public Int16 channel_type_id { get; set; }
        public string channel_type { get; set; }
        public Int16 period_type_id { get; set; }
        public string period_type { get; set; }
        public byte[] srcontent { get; set; }
        public string filetype { get; set; }
        public DateTime mature_date { get; set; }
        public DateTime effective_date { get; set; }
        public DateTime expire_date { get; set; }
        public Int16 report_flow_id { get; set; }
        public Int16 claim_flow_id { get; set; }
        public Int16 disburse_flow_id { get; set; }
        public string comments { get; set; }
        public Int16 approval_flow_id { get; set; }
        public Int16 approval_level_id { get; set; }
        public Int16 status { get; set; }
        public string current_status { get; set; }
        public DateTime current_status_date { get; set; }
        public string synched { get; set; }
        public string approvallevelname { get; set; }
        public Int16 orderid { get; set; }
        public char upload_commission_at_pos { get; set; }
        public char is_detail_required { get; set; }

        // addition
        public int DisburseByEv { get; set; }
        public decimal? DisbursementTime { get; set; }
        public int IsSetupDone { get; set; }
        // end addition

        public ReportApprovalEnt() { }

        public ReportApprovalEnt(DataRow dr)
        {

            if (dr["report_approval_id"] != DBNull.Value) { this.report_approval_id = Convert.ToInt32(dr["report_approval_id"]); }
            this.report_name = dr["report_name"] as String;
            if (dr["channel_type_id"] != DBNull.Value) { this.channel_type_id = Convert.ToInt16(dr["channel_type_id"]); }
            this.channel_type = dr["channel_type"] as String;
            if (dr["period_type_id"] != DBNull.Value) { this.period_type_id = Convert.ToInt16(dr["period_type_id"]); }
            this.period_type = dr["period_type"] as String;
            this.filetype = dr["filetype"] as String;
            if (dr["mature_date"] != DBNull.Value) { this.mature_date = Convert.ToDateTime(dr["mature_date"]); }
            if (dr["effective_date"] != DBNull.Value) { this.effective_date = Convert.ToDateTime(dr["effective_date"]); }
            if (dr["expire_date"] != DBNull.Value) { this.expire_date = Convert.ToDateTime(dr["expire_date"]); }
            if (dr["report_flow_id"] != DBNull.Value) { this.report_flow_id = Convert.ToInt16(dr["report_flow_id"]); }
            if (dr["claim_flow_id"] != DBNull.Value) { this.claim_flow_id = Convert.ToInt16(dr["claim_flow_id"]); }
            if (dr["disburse_flow_id"] != DBNull.Value) { this.disburse_flow_id = Convert.ToInt16(dr["disburse_flow_id"]); }
            this.comments = dr["comments"] as String;
            if (dr["approval_flow_id"] != DBNull.Value) { this.approval_flow_id = Convert.ToInt16(dr["approval_flow_id"]); }
            if (dr["approval_level_id"] != DBNull.Value) { this.approval_level_id = Convert.ToInt16(dr["approval_level_id"]); }
            this.status = Convert.ToInt16(dr["status"]);
            this.current_status = dr["current_status"] as String;
            if (dr["current_status_date"] != DBNull.Value) { this.current_status_date = Convert.ToDateTime(dr["current_status_date"]); }
            this.synched = dr["synched"] as String;
            this.approvallevelname = dr["approvallevelname"] as String;
            if (dr["orderid"] != DBNull.Value) { this.orderid = Convert.ToInt16(dr["orderid"]); }
            if (dr.Table.Columns.Contains("upload_commission_at_pos"))
                if (dr["upload_commission_at_pos"] != DBNull.Value)
                {
                    this.upload_commission_at_pos = Convert.ToChar(dr["upload_commission_at_pos"]);

                };
            if (dr.Table.Columns.Contains("is_detail_required"))
                if (dr["is_detail_required"] != DBNull.Value)
                {
                    this.is_detail_required = Convert.ToChar(dr["is_detail_required"]);

                };

            this.DisburseByEv = dr["DISBURSE_BY_EV"] != DBNull.Value ? Convert.ToInt16(dr["DISBURSE_BY_EV"]) : 0;
            this.IsSetupDone = Convert.ToInt16(dr["IS_SETUP_DONE"]);
            if (dr["DISBURSETIME"] != DBNull.Value) { DisbursementTime = Convert.ToDecimal(dr["DISBURSETIME"]); }

        }

    }

    public class PendingtReportApprovalEnt
    {

        public Int32 report_approval_id { get; set; }
        public string report_name { get; set; }
        public string channel_type { get; set; }
        public string period_type { get; set; }
        public DateTime effective_date { get; set; }
        public DateTime expire_date { get; set; }
        public Int16 approval_flow_id { get; set; }
        public Int16 approval_level_id { get; set; }
        public Int16 status { get; set; }
        public string current_status { get; set; }
        public string approvallevelname { get; set; }
        public Int16 orderid { get; set; }
        public string filetype { get; set; }
        public char upload_commission_at_pos { get; set; }


        public PendingtReportApprovalEnt() { }

        public PendingtReportApprovalEnt(DataRow dr)
        {

            if (dr["report_approval_id"] != DBNull.Value) { this.report_approval_id = Convert.ToInt32(dr["report_approval_id"]); }
            this.report_name = dr["report_name"] as String;
            this.channel_type = dr["channel_type"] as String;
            this.period_type = dr["period_type"] as String;
            if (dr["effective_date"] != DBNull.Value) { this.effective_date = Convert.ToDateTime(dr["effective_date"]); }
            if (dr["expire_date"] != DBNull.Value) { this.expire_date = Convert.ToDateTime(dr["expire_date"]); }
            if (dr["approval_flow_id"] != DBNull.Value) { this.approval_flow_id = Convert.ToInt16(dr["approval_flow_id"]); }
            if (dr["approval_level_id"] != DBNull.Value) { this.approval_level_id = Convert.ToInt16(dr["approval_level_id"]); }
            this.status = Convert.ToInt16(dr["status"]);
            this.current_status = dr["current_status"] as String;
            this.approvallevelname = dr["approvallevelname"] as String;
            if (dr["orderid"] != DBNull.Value) { this.orderid = Convert.ToInt16(dr["orderid"]); }
            this.filetype = dr["filetype"] as String;
            if (dr["upload_commission_at_pos"] != DBNull.Value) { this.upload_commission_at_pos = Convert.ToChar(dr["upload_commission_at_pos"]); };

        }

    }


}
