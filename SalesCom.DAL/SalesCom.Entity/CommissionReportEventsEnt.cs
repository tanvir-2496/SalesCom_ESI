using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionReportEventsEnt
    {

        public int ReportID { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }


        public CommissionReportEventsEnt() { }

        public CommissionReportEventsEnt(DataRow dr)
        {

            if (dr["ReportID"] != DBNull.Value) { this.ReportID = Convert.ToInt32(dr["ReportID"]); }
            if (dr["EventID"] != DBNull.Value) { this.EventID = Convert.ToInt32(dr["EventID"]); }
            this.EventName = dr["EventName"] as string;
        }
    }
}
