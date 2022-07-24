using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionReportEnt
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public int ChannelTypeId { get; set; }
        public string ChannelType { get; set; }
        public int IsActive { get; set; }
        public int Frequency { get; set; }
        public string KpiProcedure { get; set; }
        public int ProvisioningDay { get; set; }
        public int GenerationDay { get; set; }
        public int PeriodTypeID { get; set; }
        public int ReportGenTypeId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public byte[] SRContent { get; set; }
        

        public CommissionReportEnt() { }
        

        public CommissionReportEnt(DataRow dr)
        {
            if (dr["REPORTID"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["REPORTID"]); }
            this.ReportName = dr["REPORTNAME"] as string;
            if (dr["CHANNELTYPEID"] != DBNull.Value) { this.ChannelTypeId = Convert.ToInt32(dr["CHANNELTYPEID"]); }
            if (dr["ISACTIVE"] != DBNull.Value) { this.IsActive = Convert.ToInt32(dr["ISACTIVE"]); }
            if (dr["FREQUENCY"] != DBNull.Value) { this.Frequency = Convert.ToInt32(dr["FREQUENCY"]); }
            this.KpiProcedure = dr["KPIPROCEDURE"] as string;
            if (dr["PROVISIONINGDAY"] != DBNull.Value) { this.ProvisioningDay = Convert.ToInt32(dr["PROVISIONINGDAY"]); }
            if (dr["GENERATIONDAY"] != DBNull.Value) { this.GenerationDay = Convert.ToInt32(dr["GENERATIONDAY"]); }
            this.ChannelType = dr["ChannelType"] as string;
            if (dr["PeriodTypeID"] != DBNull.Value) { this.PeriodTypeID = Convert.ToInt32(dr["PeriodTypeID"]); }
            if (dr["ReportGenTypeId"] != DBNull.Value) { this.ReportGenTypeId = Convert.ToInt32(dr["ReportGenTypeId"]); }
            this.Name = dr["Name"] as String;
            this.FileType = dr["FileType"] as String;

        }

    }



    public class CommissionReportConciseEnt : CommissionReportEnt
    {
        public DateTime StartDate { set; get; }
        public DateTime EndDate { get; set; }
        public int ApprovalFlowId { get; set; }
        public int ClaimApprovalFlowId { get; set; }
        public int DisburseApprovalFlowId { get; set; }
        public int report_type_id { get; set; }
        public string report_type_name { set; get; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public int DelayDay { get; set; }
        public char upload_commission_at_pos { get; set; }
        public int? disburseByEvSystem { get; set; }
        public string SMSContent { get; set; }
        public decimal? DisburseTime { get; set; }
        public int SrfUploadId { get; set; }

        public CommissionReportConciseEnt() { }

        public CommissionReportConciseEnt(DataRow dr)
        {
            if (dr["REPORTID"] != DBNull.Value) { base.ReportId = Convert.ToInt32(dr["REPORTID"]); }
            base.ReportName = dr["REPORTNAME"] as string;
            if (dr["CHANNELTYPEID"] != DBNull.Value) { base.ChannelTypeId = Convert.ToInt32(dr["CHANNELTYPEID"]); }
            if (dr["ISACTIVE"] != DBNull.Value) { base.IsActive = Convert.ToInt32(dr["ISACTIVE"]); }
            if (dr["FREQUENCY"] != DBNull.Value) { base.Frequency = Convert.ToInt32(dr["FREQUENCY"]); }
            base.KpiProcedure = dr["KPIPROCEDURE"] as string;
            if (dr["PROVISIONINGDAY"] != DBNull.Value) { base.ProvisioningDay = Convert.ToInt32(dr["PROVISIONINGDAY"]); }
            if (dr["GENERATIONDAY"] != DBNull.Value) { base.GenerationDay = Convert.ToInt32(dr["GENERATIONDAY"]); }
            base.ChannelType = dr["ChannelType"] as string;
            if (dr["PeriodTypeID"] != DBNull.Value) { base.PeriodTypeID = Convert.ToInt32(dr["PeriodTypeID"]); }
            if (dr["ReportGenTypeId"] != DBNull.Value) { base.ReportGenTypeId = Convert.ToInt32(dr["ReportGenTypeId"]); }
            base.Name = dr["Name"] as String;
            base.FileType = dr["FileType"] as String;
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            if (dr["ClaimApprovalFlowId"] != DBNull.Value) { this.ClaimApprovalFlowId = Convert.ToInt32(dr["ClaimApprovalFlowId"]); }
            if (dr["DisburseApprovalFlowId"] != DBNull.Value) { this.DisburseApprovalFlowId = Convert.ToInt32(dr["DisburseApprovalFlowId"]); }
            if (dr["report_type_id"] != DBNull.Value) { this.report_type_id = Convert.ToInt32(dr["report_type_id"]); }
            this.report_type_name = dr["report_type_name"] as String;
            if (dr["DELAYDAY"] != DBNull.Value) { this.DelayDay = Convert.ToInt32(dr["DELAYDAY"]); }
            if (dr["StartDate"] != DBNull.Value) this.StartDate = Convert.ToDateTime(dr["StartDate"]);
            if (dr["EndDate"] != DBNull.Value) this.EndDate = Convert.ToDateTime(dr["EndDate"]);
            if (dr.Table.Columns.Contains("upload_commission_at_pos"))
            {
                if (dr["upload_commission_at_pos"] != DBNull.Value) { this.upload_commission_at_pos = Convert.ToChar(dr["upload_commission_at_pos"]); };
            }
            if (dr["DISBURSE_BY_EV"] != DBNull.Value) { this.disburseByEvSystem = Convert.ToInt16(dr["DISBURSE_BY_EV"]); }
            
            SMSContent = dr["SMSCONTENT"] as string;
            if (dr["DISBURSETIME"] != DBNull.Value) { DisburseTime = Convert.ToDecimal(dr["DISBURSETIME"]); }

            this.SrfUploadId = dr["SRF_UPLOAD_ID"] != DBNull.Value ? Convert.ToInt32(dr["SRF_UPLOAD_ID"]) : 0;
        }


    }


}


