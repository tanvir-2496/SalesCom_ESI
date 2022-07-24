using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class DetailSetupList
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string MonthName { get; set; }
        public int TotalReport { get; set; }

        public DetailSetupList() { }

        public DetailSetupList(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            this.ReportName = dr["REPORT_NAME"] as String;
            this.MonthName = dr["CYCLEDESCRIPTION"] as String;
            if (dr["TOTAL_REPORT"] != DBNull.Value) { this.TotalReport = Convert.ToInt32(dr["TOTAL_REPORT"]); }
        }
    }
}
