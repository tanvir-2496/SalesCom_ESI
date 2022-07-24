using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class KPIConfigurationEnt
    {
        public int KPI_CONFIG_ID { get; set; }
        public int YEAR { get; set; }
        public int QUARTER { get; set; }
        public int MONTH { get; set; }
        public int SALES_CHANNEL_ID { get; set; }
        public int KPI_ID { get; set; }
        public string KPI_NAME { get; set; }
        public int PARENT_KPI_ID { get; set; }
        public int REPORT_CYCLE_ID { get; set; }
        public int IS_LAST_LEVEL { get; set; }
        public string INCENTIVE_PAYOUT { get; set; }
        public string INCENTIVE_PAYOUT_JSON { get; set; }
        public string REMARKS { get; set; }
        public int WEIGHTAGE { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }
        public int MONTH_CYCLE_ID { get; set; }
        public KPIConfigurationEnt() { }

        public KPIConfigurationEnt(DataRow dr)
        {
            if (dr["KPI_CONFIG_ID"] != DBNull.Value) { this.KPI_CONFIG_ID = Convert.ToInt32(dr["KPI_CONFIG_ID"]); }
            if (dr["YEAR"] != DBNull.Value) this.YEAR = Convert.ToInt32(dr["YEAR"]);
            if (dr["QUARTER"] != DBNull.Value) this.QUARTER = Convert.ToInt32(dr["QUARTER"]);
            if (dr["MONTH"] != DBNull.Value) this.MONTH = Convert.ToInt32(dr["MONTH"]);
            if (dr["MONTH_CYCLE_ID"] != DBNull.Value) this.MONTH_CYCLE_ID = Convert.ToInt32(dr["MONTH_CYCLE_ID"]);
            if (dr["SALES_CHANNEL_ID"] != DBNull.Value) this.SALES_CHANNEL_ID = Convert.ToInt32(dr["SALES_CHANNEL_ID"]);
            if (dr["KPI_ID"] != DBNull.Value) this.KPI_ID = Convert.ToInt32(dr["KPI_ID"]);

            this.KPI_NAME = dr["KPI_NAME"] as String;
            if (dr["PARENT_KPI_ID"] != DBNull.Value) this.PARENT_KPI_ID = Convert.ToInt32(dr["PARENT_KPI_ID"]);
            if (dr["REPORT_CYCLE_ID"] != DBNull.Value) this.REPORT_CYCLE_ID = Convert.ToInt32(dr["REPORT_CYCLE_ID"]);
            if (dr["IS_LAST_LEVEL"] != DBNull.Value) this.IS_LAST_LEVEL = Convert.ToInt32(dr["IS_LAST_LEVEL"]);
            this.INCENTIVE_PAYOUT = dr["INCENTIVE_PAYOUT"] as String;
            this.REMARKS = dr["REMARKS"] as String;
            if (dr["WEIGHTAGE"] != DBNull.Value) this.WEIGHTAGE = Convert.ToInt32(dr["WEIGHTAGE"]);
           
            if (dr["CREATED_BY"] != DBNull.Value) this.Created_By = Convert.ToInt32(dr["CREATED_BY"]);
            if (dr["CREATED_DATE"] != DBNull.Value) this.Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]);
            if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
        }
    }
}
