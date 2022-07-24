using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class AdHocReportEnt
    {
        public Int32 ad_hoc_report_id { get; set; }
        public string report_name { get; set; }
        public Int16 channel_type_id { get; set; }
        public Int16 is_active { get; set; }
        public Int16 period_type_id { get; set; }
        public Int16 report_gen_type { get; set; }
        public Int16 report_flow_id { get; set; }
        public Int16 claim_flow_id { get; set; }
        public Int16 disburse_flow_id { get; set; }
        public Int32 create_by { get; set; }
        public DateTime create_date { get; set; }
        public Int32 update_by { get; set; }
        public DateTime update_date { get; set; }
        public byte[] sr_content { get; set; }
        public string file_type { get; set; }
        public string channeltype { get; set; }
        public string periodtypename { get; set; }
        public string name { get; set; }
        public string approvalname { get; set; }
        public int? disburseByEvSystem { get; set; }
        public string SMSContent { get; set; }
        public decimal? DisburseTime { get; set; }

        // Addition
        public int SrfUploadId { get; set; }
        // addition

        public AdHocReportEnt() { }

        public AdHocReportEnt(DataRow dr)
        {

            if (dr["ad_hoc_report_id"] != DBNull.Value) { this.ad_hoc_report_id = Convert.ToInt32(dr["ad_hoc_report_id"]); }
            this.report_name = dr["report_name"] as String;
            if (dr["channel_type_id"] != DBNull.Value) { this.channel_type_id = Convert.ToInt16(dr["channel_type_id"]); }
            if (dr["is_active"] != DBNull.Value) { this.is_active = Convert.ToInt16(dr["is_active"]); }
            if (dr["period_type_id"] != DBNull.Value) { this.period_type_id = Convert.ToInt16(dr["period_type_id"]); }
            if (dr["report_gen_type"] != DBNull.Value) { this.report_gen_type = Convert.ToInt16(dr["report_gen_type"]); }
            if (dr["report_flow_id"] != DBNull.Value) { this.report_flow_id = Convert.ToInt16(dr["report_flow_id"]); }
            if (dr["claim_flow_id"] != DBNull.Value) { this.claim_flow_id = Convert.ToInt16(dr["claim_flow_id"]); }
            if (dr["disburse_flow_id"] != DBNull.Value) { this.disburse_flow_id = Convert.ToInt16(dr["disburse_flow_id"]); }
            if (dr["create_by"] != DBNull.Value) { this.create_by = Convert.ToInt32(dr["create_by"]); }
            if (dr["create_date"] != DBNull.Value) { this.create_date = Convert.ToDateTime(dr["create_date"]); }
            if (dr["update_by"] != DBNull.Value) { this.update_by = Convert.ToInt32(dr["update_by"]); }
            if (dr["update_date"] != DBNull.Value) { this.update_date = Convert.ToDateTime(dr["update_date"]); }
            if (dr["DISBURSE_BY_EV"] != DBNull.Value) { this.disburseByEvSystem = Convert.ToInt16(dr["DISBURSE_BY_EV"]); }
            this.file_type = dr["file_type"] as String;
            this.channeltype = dr["channeltype"] as String;
            this.periodtypename = dr["periodtypename"] as String;
            this.name = dr["name"] as String;
            this.approvalname = dr["approvalname"] as String;
            this.SMSContent = dr["SMSCONTENT"] as string;
            if (dr["DISBURSETIME"] != DBNull.Value) { this.DisburseTime = Convert.ToDecimal(dr["DISBURSETIME"]); }

            this.SrfUploadId = dr["SRF_UPLOAD_ID"] != DBNull.Value ? Convert.ToInt32(dr["SRF_UPLOAD_ID"]) : 0;
        }


    }


    public class AdHocReportList
    {
        public Int32 ad_hoc_report_id { get; set; }
        public string report_name { get; set; }
       

        public AdHocReportList() { }

        public AdHocReportList(DataRow dr)
        {

            if (dr["ad_hoc_report_id"] != DBNull.Value) { this.ad_hoc_report_id = Convert.ToInt32(dr["ad_hoc_report_id"]); }
            this.report_name = dr["report_name"] as String;

        }


    }

}
