using System;
using System.Data;

namespace SalesCom.Entity
{
    public class AdHocPendingApprovalEnt
    {
        public Int32 Id { get; set; }
        public Int32 report_id { get; set; }
        public Int32 cycle_id { get; set; }
        public Int16 flow_id { get; set; }
        public Int16 level_id { get; set; }
        public string report_name { get; set; }
        public DateTime report_date { get; set; }
        public DateTime generation_date { get; set; }
        public string approvallevelname { get; set; }
        public string commission_amount { get; set; }
        public string approvalname { get; set; }
        public Int16 orderid { get; set; }

        public AdHocPendingApprovalEnt() { }

        public AdHocPendingApprovalEnt(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            if (dr["report_id"] != DBNull.Value) { this.report_id = Convert.ToInt32(dr["report_id"]); }
            if (dr["cycle_id"] != DBNull.Value) { this.cycle_id = Convert.ToInt32(dr["cycle_id"]); }
            if (dr["flow_id"] != DBNull.Value) { this.flow_id = Convert.ToInt16(dr["flow_id"]); }
            if (dr["level_id"] != DBNull.Value) { this.level_id = Convert.ToInt16(dr["level_id"]); }
            this.report_name = dr["report_name"] as String;
            if (dr["report_date"] != DBNull.Value) { this.report_date = Convert.ToDateTime(dr["report_date"]); }
            if (dr["generation_date"] != DBNull.Value) { this.generation_date = Convert.ToDateTime(dr["generation_date"]); }
            this.approvallevelname = dr["approvallevelname"] as String;
            this.commission_amount = dr["commission_amount"] as String;
            this.approvalname = dr["approvalname"] as String;
            if (dr["orderid"] != DBNull.Value) { this.orderid = Convert.ToInt16(dr["orderid"]); }

        }

    }

    public class ApprovalHistory
    {
        public string approvallevelname { get; set; }
        public string status { get; set; }
        public string comments { get; set; }
        public string user_name { get; set; }
        public DateTime create_date { get; set; }

        public ApprovalHistory() { }

        public ApprovalHistory(DataRow dr)
        {
            this.approvallevelname = dr["approvallevelname"] as String;
            this.status = dr["status"] as String;
            this.comments = dr["comments"] as String;
            this.user_name = dr["user_name"] as String;
            if (dr["create_date"] != DBNull.Value) { this.create_date = Convert.ToDateTime(dr["create_date"]); }
        }

    }


    public class ApprovalDetail
    {
        public Int32 Id { get; set; }
        public string ReportName { get; set; }
        public string ReportDate { get; set; }
        public string ReportGenDate { get; set; }
        public string Commission { get; set; }
        public Int16 FlowId { get; set; }
        public string LevelName { get; set; }
        public Int16 LevelId { get; set; }
        public Int16 Order { get; set; }
        public Int16 Status { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }


    public class AdHocReportViewEnt
    {
        public Int32 report_id { get; set; }
        public Int32 cycle_id { get; set; }
        public string report_name { get; set; }
        public DateTime report_date { get; set; }
        public DateTime generation_date { get; set; }
        public string Status { get; set; }
        public string commission_amount { get; set; }

        public AdHocReportViewEnt() { }

        public AdHocReportViewEnt(DataRow dr)
        {
            if (dr["report_id"] != DBNull.Value) { this.report_id = Convert.ToInt32(dr["report_id"]); }
            if (dr["cycle_id"] != DBNull.Value) { this.cycle_id = Convert.ToInt32(dr["cycle_id"]); }
            this.report_name = dr["report_name"] as String;
            if (dr["report_date"] != DBNull.Value) { this.report_date = Convert.ToDateTime(dr["report_date"]); }
            if (dr["generation_date"] != DBNull.Value) { this.generation_date = Convert.ToDateTime(dr["generation_date"]); }
            this.Status = dr["Status"] as String;
            this.commission_amount = dr["commission_amount"] as String;
        }
    }


    public class AdHocSummaryReport
    {
        public string report_duration { get; set; }
        public string commission_amount { get; set; }
        public string ait { get; set; }
        public string disburse_amount { get; set; }
                  
      

        public AdHocSummaryReport() { }

        public AdHocSummaryReport(DataRow dr)
        {
            this.report_duration = dr["report_duration"] as String;
            this.commission_amount = dr["commission_amount"] as String;
            this.ait = dr["ait"] as String;
            this.disburse_amount = dr["disburse_amount"] as String;
        }
    }

}
