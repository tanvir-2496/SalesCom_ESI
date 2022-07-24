using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ReportKpiListForHalt
    {
        public int REPORT_CYCLE_ID { get; set; }
        public int KPI_ID { get; set; }
        public string KPI_NAME { get; set; }
        public int SUB_KPI_ID { get; set; }
        public string SUB_KPI_NAME { get; set; }
        public int KPI_IS_KPI_HALT { get; set; }
        public int SUBKPI_IS_KPI_HALT { get; set; }
        public string HALT_STATUS { get; set; }

        public ReportKpiListForHalt() { }

        public ReportKpiListForHalt(DataRow dr)
        {
            if (dr["REPORT_CYCLE_ID"] != DBNull.Value) { this.REPORT_CYCLE_ID = Convert.ToInt32(dr["REPORT_CYCLE_ID"]); }
            if (dr["KPI_ID"] != DBNull.Value) { this.KPI_ID = Convert.ToInt32(dr["KPI_ID"]); }
            this.KPI_NAME = dr["KPI_NAME"] as String;
            if (dr["SUB_KPI_ID"] != DBNull.Value) { this.SUB_KPI_ID = Convert.ToInt32(dr["SUB_KPI_ID"]); }
            this.SUB_KPI_NAME = dr["SUB_KPI_NAME"] as String;
            if (dr["KPI_IS_KPI_HALT"] != DBNull.Value) this.KPI_IS_KPI_HALT = Convert.ToInt32(dr["KPI_IS_KPI_HALT"]);
            this.HALT_STATUS = dr["HALT_STATUS"] as String;
            if (dr["SUBKPI_IS_KPI_HALT"] != DBNull.Value) this.SUBKPI_IS_KPI_HALT = Convert.ToInt32(dr["SUBKPI_IS_KPI_HALT"]);
        }
    }
}
