using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionReportSegmentsEnt
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public int SegmentId { get; set; }
        public string SegmentName { get; set; }
        public int EventTypeId { get; set; }
        public string EventType { get; set; }
        public int MinimumTargetPercentage { get; set; }
        public int MaximumTargetPercentage { get; set; }
        public int MinimumTargetAmount { get; set; }
        public int MaximumTargetAmount { get; set; }
        public int Amount { get; set; }

        public int SegmentAmount { get; set; }
        public int EventPercentage { get; set; }


        public CommissionReportSegmentsEnt() { }

        public CommissionReportSegmentsEnt(DataRow dr)
        {
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            this.ReportName = dr["ReportName"] as String;
            if (dr["SegmentId"] != DBNull.Value) { this.SegmentId = Convert.ToInt32(dr["SegmentId"]); }
            this.SegmentName = dr["SegmentName"] as String;
            if (dr["EventTypeId"] != DBNull.Value) { this.EventTypeId = Convert.ToInt32(dr["EventTypeId"]); }
            this.EventType = dr["EventType"] as String;
            if (dr["MinimumTargetPercentage"] != DBNull.Value) { this.MinimumTargetPercentage = Convert.ToInt32(dr["MinimumTargetPercentage"]); }
            if (dr["MaximumTargetPercentage"] != DBNull.Value) { this.MaximumTargetPercentage = Convert.ToInt32(dr["MaximumTargetPercentage"]); }

            if (dr["MinimumTargetAmount"] != DBNull.Value) { this.MinimumTargetAmount = Convert.ToInt32(dr["MinimumTargetAmount"]); }
            if (dr["MaximumTargetAmount"] != DBNull.Value) { this.MaximumTargetAmount = Convert.ToInt32(dr["MaximumTargetAmount"]); }

            if (dr["Amount"] != DBNull.Value) { this.Amount = Convert.ToInt32(dr["Amount"]); }

            if (dr["SegmentAmount"] != DBNull.Value) { this.SegmentAmount = Convert.ToInt32(dr["SegmentAmount"]); }
            if (dr["EventPercentage"] != DBNull.Value) { this.EventPercentage = Convert.ToInt32(dr["EventPercentage"]); }

        }
    }
}
