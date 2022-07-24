using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportPreExeConfigEnt
    {
        public Int32 ReportId { get; set; }
        public Int32 CycleReportId { get; set; }
        public Int32 ReportGenTypeId { get; set; }
        public string ReportName { get; set; }
        public Int32 CycleId { get; set; }
        public string CommissionCycle { get; set; }
        public Int32 PublishCycleId { get; set; }
        public string PublishCycle { get; set;}
        public Int16 Status { get; set; }
        public Int32 ProvisionCycleId { get; set; }
        public string ProvisionCycle { get; set; }
        public DateTime ProvisionFromDate { get; set; }
        public DateTime ProvisionToDate { get; set; }
        public DateTime ReportFromDate { get; set; }
        public DateTime ReportToDate { get; set; }

        public ReportPreExeConfigEnt() { }

        public ReportPreExeConfigEnt(DataRow dr)
        {
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            if (dr["CycleReportId"] != DBNull.Value) { this.CycleReportId = Convert.ToInt32(dr["CycleReportId"]); }
            if (dr["ReportGenTypeId"] != DBNull.Value) { this.ReportGenTypeId = Convert.ToInt32(dr["ReportGenTypeId"]); }
            this.ReportName = dr["ReportName"] as String;
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.CommissionCycle = dr["CommissionCycle"] as String;
            if (dr["PublishCycleId"] != DBNull.Value) { this.PublishCycleId = Convert.ToInt32(dr["PublishCycleId"]); }
            this.PublishCycle = dr["PublishCycle"] as String;
            if (dr["Status"] != DBNull.Value) { this.Status = Convert.ToInt16(dr["Status"]); }
            if (dr["ProvisionCycleId"] != DBNull.Value) { this.ProvisionCycleId = Convert.ToInt32(dr["ProvisionCycleId"]); }
            this.ProvisionCycle = dr["ProvisionCycle"] as String;
            if (dr["ProvisionFromDate"] != DBNull.Value) { this.ProvisionFromDate = Convert.ToDateTime(dr["ProvisionFromDate"]); }
            if (dr["ProvisionToDate"] != DBNull.Value) { this.ProvisionToDate = Convert.ToDateTime(dr["ProvisionToDate"]); }
            if (dr["ReportFromDate"] != DBNull.Value) { this.ReportFromDate = Convert.ToDateTime(dr["ReportFromDate"]); }
            if (dr["ReportToDate"] != DBNull.Value) { this.ReportToDate = Convert.ToDateTime(dr["ReportToDate"]); }
        }
    }
}
