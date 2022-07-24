using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class KPIvsAchievementForHigherEnt
    {
        public int Employee_Id { get; set; }
        public int Kpi_Id { get; set; }
        public string KPIName { get; set; }
        public int Weightage { get; set; }
        public decimal M1_ACH { get; set; }
        public decimal M2_ACH { get; set; }
        public decimal M3_ACH { get; set; }
        public decimal M1_AMOUNT { get; set; }
        public decimal M2_AMOUNT { get; set; }
        public decimal M3_AMOUNT { get; set; }
        public decimal M1_TARGET { get; set; }
        public decimal M2_TARGET { get; set; }
        public decimal M3_TARGET { get; set; }
        public string COLOR_CHANGE { get; set; } 

        public int TotalQuarterAchievement { get; set; } 

         public KPIvsAchievementForHigherEnt() { }

         public KPIvsAchievementForHigherEnt(DataRow dr)
        {
            if (dr["Employee_Id"] != DBNull.Value) this.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);
            if (dr["Kpi_Id"] != DBNull.Value) { this.Kpi_Id = Convert.ToInt32(dr["Kpi_Id"]); }
            this.KPIName = dr["KPI_NAME"] as String;
            if (dr["Weightage"] != DBNull.Value) this.Employee_Id = Convert.ToInt32(dr["Weightage"]);
            if (dr["M1_ACH"] != DBNull.Value) this.M1_ACH = Convert.ToDecimal(dr["M1_ACH"]);
            if (dr["M2_ACH"] != DBNull.Value) this.M2_ACH = Convert.ToDecimal(dr["M2_ACH"]);
            if (dr["M3_ACH"] != DBNull.Value) this.M3_ACH = Convert.ToDecimal(dr["M3_ACH"]);

            if (dr["M1_AMOUNT"] != DBNull.Value) this.M1_AMOUNT = Convert.ToDecimal(dr["M1_AMOUNT"]);
            if (dr["M2_AMOUNT"] != DBNull.Value) this.M2_AMOUNT = Convert.ToDecimal(dr["M2_AMOUNT"]);
            if (dr["M3_AMOUNT"] != DBNull.Value) this.M3_AMOUNT = Convert.ToDecimal(dr["M3_AMOUNT"]);

            if (dr["M1_TARGET"] != DBNull.Value) this.M1_TARGET = Convert.ToDecimal(dr["M1_TARGET"]);
            if (dr["M2_TARGET"] != DBNull.Value) this.M2_TARGET = Convert.ToDecimal(dr["M2_TARGET"]);
            if (dr["M3_TARGET"] != DBNull.Value) this.M3_TARGET = Convert.ToDecimal(dr["M3_TARGET"]);

            this.COLOR_CHANGE = dr["COLOR_CHANGE"] as String;
            if (dr["TotalQuarterAchievement"] != DBNull.Value) this.TotalQuarterAchievement = Convert.ToInt32(dr["TotalQuarterAchievement"]);
            //if (dr["QuarterlyAchievementThresholds"] != DBNull.Value) this. = Convert.ToInt32(dr["QuarterlyAchievementThresholds"]);
            //if (dr["EligibleAsPerConditions"] != DBNull.Value) this.EligibleAsPerConditions = Convert.ToInt32(dr["EligibleAsPerConditions"]);
        }
    }
}
