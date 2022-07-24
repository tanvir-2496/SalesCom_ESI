using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ChannelWithdrawalEnt
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string ChannelId { get; set; }
        public string ImportedBy { get; set; }
        public DateTime ImportDate { get; set; }
        public string ReportName { get; set; }
        public string ChannelCode { get; set; }
        public string ChannelName { get; set; }
        public string ReferenceNumber { get; set; }

        public ChannelWithdrawalEnt() { }

        public ChannelWithdrawalEnt(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            this.ChannelId = dr["ChannelId"] as String;
            this.ImportedBy = dr["ImportedBy"] as String;
            if (dr["ImportDate"] != DBNull.Value) { this.ImportDate = Convert.ToDateTime(dr["ImportDate"]); }
            this.ReportName = dr["ReportName"] as String;
            this.ChannelCode = dr["ChannelCode"] as String;
            this.ChannelName = dr["ChannelName"] as String;
            this.ReferenceNumber = dr["ReferenceNumber"] as String;
        }
    }
}
