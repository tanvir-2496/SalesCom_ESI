using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ReportCycleEnt
    {
        public int REPORT_CYCLE_ID { get; set; }
        public int REPORT_TYPE { get; set; }
        public int YEAR { get; set; }
        public int QUARTER { get; set; }
        public int MONTH { get; set; }
        public int SALES_CHANNEL_ID { get; set; }
        public DateTime MATURE_DATE { get; set; }
       
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }


        public ReportCycleEnt() { }

        public ReportCycleEnt(DataRow dr)
        {
            if (dr["REPORT_CYCLE_ID"] != DBNull.Value) { this.REPORT_CYCLE_ID = Convert.ToInt32(dr["REPORT_CYCLE_ID"]); }
            if (dr["REPORT_TYPE"] != DBNull.Value) this.REPORT_TYPE = Convert.ToInt32(dr["REPORT_TYPE"]);
            if (dr["YEAR"] != DBNull.Value) this.YEAR = Convert.ToInt32(dr["YEAR"]);
            if (dr["QUARTER"] != DBNull.Value) this.QUARTER = Convert.ToInt32(dr["QUARTER"]);
            if (dr["MONTH"] != DBNull.Value) this.MONTH = Convert.ToInt32(dr["MONTH"]);
            if (dr["SALES_CHANNEL_ID"] != DBNull.Value) this.SALES_CHANNEL_ID = Convert.ToInt32(dr["SALES_CHANNEL_ID"]);
            if (dr["MATURE_DATE"] != DBNull.Value) this.MATURE_DATE = Convert.ToDateTime(dr["MATURE_DATE"]);
           
            if (dr["CREATED_BY"] != DBNull.Value) this.Created_By = Convert.ToInt32(dr["CREATED_BY"]);
            if (dr["CREATED_DATE"] != DBNull.Value) this.Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]);
            if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
        }
    }
}
