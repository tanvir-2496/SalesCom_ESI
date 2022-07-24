using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class PendingApprovalEnt
    {
        public int PendingApprovalId { get; set; }
        public int LevelId { get; set; }
        public int ApprovalflowId { get; set; }
        public int ReportCycleId { get; set; }
        public string LevelName { get; set; }
        public string ApprovalflowName { get; set; }
        public string Comments { get; set; }
        public int OrderId { get; set; }
        public string BaseMoth { get; set; }
        public string PublishedMonth { get; set; }
        public string ReportName { get; set; }
        public string CommissionAmount { get; set; }
        public string COMMISSIONAMOUNTWithdrawal { get; set; }
        public int ReportId { get; set; }
        public int CycleId { get; set; }
        public int ClaimId { get; set; }
        public string FileType { get; set; }


        public PendingApprovalEnt()
        { }

        public PendingApprovalEnt(DataRow dr)
        {
            if (dr["PENDINGAPPROVALID"] != DBNull.Value) { this.PendingApprovalId = Convert.ToInt32(dr["PENDINGAPPROVALID"]); }
            if (dr["LEVELID"] != DBNull.Value) { this.LevelId = Convert.ToInt32(dr["LEVELID"]); }
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalflowId = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            if (dr["ReportCycleId"] != DBNull.Value) { this.ReportCycleId = Convert.ToInt32(dr["ReportCycleId"]); }
            this.LevelName = dr["LevelName"] as string;
            this.ApprovalflowName = dr["ApprovalflowName"] as string;
            this.Comments = dr["Comments"] as String;
            if (dr["ORDERID"] != DBNull.Value) { this.OrderId = Convert.ToInt32(dr["ORDERID"]); }
            this.BaseMoth = dr["BaseMoth"] as String;
            this.PublishedMonth = dr["PublishedMonth"] as String;
            this.ReportName = dr["ReportName"] as String;
            this.CommissionAmount = dr["CommissionAmount"] as String;
            this.COMMISSIONAMOUNTWithdrawal = dr["COMMISSIONAMOUNTWithdrawal"] as  String;
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            if (dr["ClaimId"] != DBNull.Value) { this.ClaimId = Convert.ToInt32(dr["ClaimId"]); }
            this.FileType = dr["FileType"] as String;
        }
    }


    public class PendingApprovalWithStatusAndCommentEnt
    {
        public int PendingApprovalId { get; set; }
        public int LevelId { get; set; }
        public int ApprovalFlowId { get; set; }
        public int CycleId { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
        public int OrderId { get; set; }

        public PendingApprovalWithStatusAndCommentEnt()
        { }

        public PendingApprovalWithStatusAndCommentEnt(DataRow dr)
        {
            if (dr["PENDINGAPPROVALID"] != DBNull.Value) { this.PendingApprovalId = Convert.ToInt32(dr["PENDINGAPPROVALID"]); }
            if (dr["LEVELID"] != DBNull.Value) { this.LevelId = Convert.ToInt32(dr["LEVELID"]); }
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            if (dr["CYCLEID"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CYCLEID"]); }
            if (dr["STATUS"] != DBNull.Value) { this.Status = Convert.ToInt32(dr["STATUS"]); }
            this.Comments = dr["COMMENTS"] as String;
            if (dr["ORDERID"] != DBNull.Value) { this.OrderId = Convert.ToInt32(dr["ORDERID"]); }
        }
    }

}
