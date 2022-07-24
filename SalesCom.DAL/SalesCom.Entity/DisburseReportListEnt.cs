using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class DisburseReportListEnt
    {
        public int report_cycle_id { get; set; }
        public string reportname { get; set; }
        public string report_duration { get; set; }
        public string claim_amt { get; set; }
        public string withheld_amt { get; set; }
        public string disburse_amt { get; set; }

        public DisburseReportListEnt()
        {
        }

        public DisburseReportListEnt(DataRow dr)
        {
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            this.reportname = dr["reportname"] as String;
            this.report_duration = dr["report_duration"] as String;
            this.claim_amt = dr["claim_amt"] as String;
            this.withheld_amt = dr["withheld_amt"] as String;
            this.disburse_amt = dr["disburse_amt"] as String;
        }
    }
}
