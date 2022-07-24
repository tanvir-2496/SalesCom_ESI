using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class PendingApprovalSummaryViewEnt
    {
        public Int64 ChannelId { get; set; }
        public string ChannelCode { get; set; }
        public string ChannelName { get; set; }
        //public decimal CommissionAmount { get; set; }
        public string Commission { get; set; }
        public int CycleReportID { get; set; }

        public PendingApprovalSummaryViewEnt() { }

        public PendingApprovalSummaryViewEnt(DataRow dr)
        {
            if (dr["CHANNELID"] != DBNull.Value) { this.ChannelId = Convert.ToInt32(dr["CHANNELID"]); }
            this.ChannelCode = dr["CHANNELCODE"] as String;
            this.ChannelName = dr["CHANNELNAME"] as String;
            //if (dr["COMMISSIONAMOUNT"] != DBNull.Value) { this.CommissionAmount = Convert.ToDecimal(dr["COMMISSIONAMOUNT"]); }
            this.Commission = dr["Commission"] as String;
            if (dr["CycleReportID"] != DBNull.Value) { this.CycleReportID = Convert.ToInt32(dr["CycleReportID"]); }
        }

    }
}
