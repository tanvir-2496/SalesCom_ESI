using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class DenoReportApprovalEnt
    {
        public Int32 id { get; set; }
        public string report_name { get; set; }
        public Int16 channel_type_id { get; set; }
        public Int16 deno_type_id { get; set; }
        public string channel_type { get; set; }      
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }     
        public string comments { get; set; }
        public Int16 approval_flow_id { get; set; }
        public Int16 approval_level_id { get; set; }
        public Int16 status { get; set; }
        public string current_status { get; set; }
        public DateTime current_status_date { get; set; }       
        public string approvallevelname { get; set; }
        public Int16 orderid { get; set; }



        public DenoReportApprovalEnt() { }

        public DenoReportApprovalEnt(DataRow dr)
        {

            if (dr["id"] != DBNull.Value) { this.id = Convert.ToInt32(dr["id"]); }
            this.report_name = dr["camp_name"] as String;
            if (dr["channel_type_id"] != DBNull.Value) { this.channel_type_id = Convert.ToInt16(dr["channel_type_id"]); }
            this.channel_type = dr["channel_type"] as String;
            if (dr["effective_date"] != DBNull.Value) { this.start_date = Convert.ToDateTime(dr["camp_start_date"]); }
            if (dr["expire_date"] != DBNull.Value) { this.end_date = Convert.ToDateTime(dr["camp_end_date"]); }
            if (dr["deno_type_id"] != DBNull.Value) { this.deno_type_id = Convert.ToInt16(dr["deno_type_id"]); }
            this.comments = dr["comments"] as String;
            if (dr["approval_flow_id"] != DBNull.Value) { this.approval_flow_id = Convert.ToInt16(dr["approval_flow_id"]); }
            if (dr["approval_level_id"] != DBNull.Value) { this.approval_level_id = Convert.ToInt16(dr["approval_level_id"]); }
            this.status = Convert.ToInt16(dr["status"]);
            this.current_status = dr["current_status"] as String;
            if (dr["current_status_date"] != DBNull.Value) { this.current_status_date = Convert.ToDateTime(dr["current_status_date"]); }        
            this.approvallevelname = dr["approvallevelname"] as String;
            if (dr["orderid"] != DBNull.Value) { this.orderid = Convert.ToInt16(dr["orderid"]); }
           

        }

    }

    public class DenoPendingApprovalList
    {
        public Int32 id { get; set; }
        public string report_name { get; set; }
        //public string channel_type { get; set; }        
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public Int16 DenoTypeId { get; set; }
        public Int16 approval_flow_id { get; set; }
        public Int16 approval_level_id { get; set; }
        public Int16 status { get; set; }
        public string current_status { get; set; }
        public string approvallevelname { get; set; }
        public Int16 orderid { get; set; }      
   


        public DenoPendingApprovalList() { }

        public DenoPendingApprovalList(DataRow dr)
        {

            if (dr["id"] != DBNull.Value) { this.id = Convert.ToInt32(dr["id"]); }
            this.report_name = dr["CAMP_NAME"] as String;
            //this.channel_type = dr["channel_type"] as String;
            if (dr["CAMP_START_DATE"] != DBNull.Value) { this.start_date = Convert.ToDateTime(dr["CAMP_START_DATE"]); }
            if (dr["CAMP_END_DATE"] != DBNull.Value) { this.end_date = Convert.ToDateTime(dr["CAMP_END_DATE"]); }
            if (dr["DenoTypeId"] != DBNull.Value) { this.DenoTypeId = Convert.ToInt16(dr["DenoTypeId"]); }
            if (dr["approval_flow_id"] != DBNull.Value) { this.approval_flow_id = Convert.ToInt16(dr["approval_flow_id"]); }
            if (dr["approval_level_id"] != DBNull.Value) { this.approval_level_id = Convert.ToInt16(dr["approval_level_id"]); }
            this.status = Convert.ToInt16(dr["status"]);
            this.current_status = dr["current_status"] as String;
            this.approvallevelname = dr["approvallevelname"] as String;
            if (dr["orderid"] != DBNull.Value) { this.orderid = Convert.ToInt16(dr["orderid"]); }
          
        }
    }
}
