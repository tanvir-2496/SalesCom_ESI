using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionReportAllEnt
    {
        public Int64 ChannelId { get; set; }
        public string ChannelCode { get; set; }
        public string ChannelName { get; set; }
        public string RetailerCode { get; set; }
        public string RetailerName { get; set; }
        public decimal CommissionAmount { get; set; }


        public CommissionReportAllEnt() { }

        public CommissionReportAllEnt(DataRow dr)
        {
            if (dr["channelid"] != DBNull.Value) { this.ChannelId = Convert.ToInt64(dr["channelid"]); }
            this.ChannelCode = dr["CHANNELCODE"] as String;
            this.ChannelName = dr["CHANNELNAME"] as String;
            this.RetailerCode = dr["RETAILERCODE"] as String;
            this.RetailerName = dr["RETAILERNAME"] as String;
            if (dr["COMMISSIONAMOUNT"] != DBNull.Value) { this.CommissionAmount = Convert.ToInt64(dr["COMMISSIONAMOUNT"]); }
        }


    }
}
