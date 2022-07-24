using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportViewEnt
    {
        public string ReportName { get; set; }
        public int ReportId { get; set; }
        public int CycleReportId { get; set; }
        public int CycleId { get; set; }
        public string CycleDesc { get; set; }
        public double CommissionAmount { get; set; }
        public string LevelName { get; set; }

        public ReportViewEnt() { }

        public ReportViewEnt(DataRow dr)
        {
            this.ReportName = dr["ReportName"] as String;
            if (dr["ReportId"] != DBNull.Value) { this.ReportId = Convert.ToInt32(dr["ReportId"]); }
            if (dr["CycleReportId"] != DBNull.Value) { this.CycleReportId = Convert.ToInt32(dr["CycleReportId"]); }
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.CycleDesc = dr["CycleDesc"] as String;
            if (dr["CommissionAmount"] != DBNull.Value) { this.CommissionAmount = Convert.ToInt32(dr["CommissionAmount"]); }
            this.LevelName = dr["LevelName"] as String;



        }
    }



    public class ReportViewWithMonth : ReportViewEnt
    {
        public string BaseMonth { get; set; }
        public string PublishMonth { get; set; }
        public string TotalAmount { get; set; }

        public ReportViewWithMonth() { }

        public ReportViewWithMonth(DataRow dr)
        {
            this.BaseMonth = dr["BaseMonth"] as String;
            this.PublishMonth = dr["PublishMonth"] as String;

            base.ReportName = dr["ReportName"] as String;
            if (dr["ReportId"] != DBNull.Value) { base.ReportId = Convert.ToInt32(dr["ReportId"]); }
            if (dr["CycleReportId"] != DBNull.Value) { base.CycleReportId = Convert.ToInt32(dr["CycleReportId"]); }
            if (dr["CycleId"] != DBNull.Value) { base.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.TotalAmount = dr["TotalAmount"] as String;
            base.LevelName = dr["LevelName"] as String;

        }
    }


    public class ReportViewWithTotal : ReportViewEnt
    {
        public string TotalAmount { get; set; }

        public ReportViewWithTotal() { }

        public ReportViewWithTotal(DataRow dr)
        {
            base.ReportName = dr["ReportName"] as String;
            if (dr["ReportId"] != DBNull.Value) { base.ReportId = Convert.ToInt32(dr["ReportId"]); }
            if (dr["CycleReportId"] != DBNull.Value) { base.CycleReportId = Convert.ToInt32(dr["CycleReportId"]); }
            if (dr["CycleId"] != DBNull.Value) { base.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.TotalAmount = dr["TotalAmount"] as String;
            base.LevelName = dr["LevelName"] as String;
            base.CycleDesc = dr["CYCLEDESC"] as String;

        }
    }


}
