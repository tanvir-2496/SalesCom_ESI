using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionCycleReportsEnt
    {
        public int CycleReportId { get; set; }
        public int ReportId { get; set; }
        public int CycleId { get; set; }
        public int Version { get; set; }
        public int ReportStage { get; set; }
        public string Status { get; set; }

        public CommissionCycleReportsEnt() { }

        public CommissionCycleReportsEnt(DataRow dr)
        {
            if (dr["CycleReportId"] != DBNull.Value) { this.CycleReportId = Convert.ToInt32(dr["CycleReportId"]); }
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            if (dr["Version"] != DBNull.Value) { this.Version = Convert.ToInt32(dr["Version"]); }
            if (dr["ReportStage"] != DBNull.Value) { this.ReportStage = Convert.ToInt32(dr["ReportStage"]); }
            this.Status = dr["Status"] as String;
        }
    }
}
