using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class KPIvsAchievementEnt
    {
        public int Employee_Id { get; set; }
        public int Kpi_Id { get; set; }
        public string KPIType { get; set; }
        public string KPIName { get; set; }
        public int Weightage { get; set; }
        public int M1_ACH { get; set; }
        public int M2_ACH { get; set; }
        public int M3_ACH { get; set; }
        public int M1_AMOUNT { get; set; }
        public int M2_AMOUNT { get; set; }
        public int M3_AMOUNT { get; set; }
        public int M1_TARGET { get; set; }
        public int M2_TARGET { get; set; }
        public int M3_TARGET { get; set; }
        public int TotalQuarterTARGET { get; set; }
        public int TotalQuarterAMOUNT { get; set; }

        public int IncentiveEntitlement { get; set; }
        public int TotalQuarterAchievement { get; set; } 
        public string QuarterlyAchievementThresholds { get; set; }
        public string EligibleAsPerConditions { get; set; } 
        public int EligibleIncentiveAmount { get; set; }
        public string COLOR_CHANGE { get; set; }
        public int PreviousIncentiveAmount { get; set; }
        public int AdjustIncentiveAmount { get; set; }

         public KPIvsAchievementEnt() { }

         public KPIvsAchievementEnt(DataRow dr)
        {
            if (dr["Employee_Id"] != DBNull.Value) this.Employee_Id = Convert.ToInt32(dr["Employee_Id"]);
            if (dr["Kpi_Id"] != DBNull.Value) { this.Kpi_Id = Convert.ToInt32(dr["Kpi_Id"]); }
            this.KPIType = dr["KPI_TYPE"] as String;
            this.KPIName = dr["KPI_NAME"] as String;
            if (dr["Weightage"] != DBNull.Value) this.Employee_Id = Convert.ToInt32(dr["Weightage"]);
            if (dr["M1_ACH"] != DBNull.Value) this.M1_ACH = Convert.ToInt32(dr["M1_ACH"]);
            if (dr["M2_ACH"] != DBNull.Value) this.M2_ACH = Convert.ToInt32(dr["M2_ACH"]);
            if (dr["M3_ACH"] != DBNull.Value) this.M3_ACH = Convert.ToInt32(dr["M3_ACH"]);

            if (dr["M1_AMOUNT"] != DBNull.Value) this.M1_AMOUNT = Convert.ToInt32(dr["M1_AMOUNT"]);
            if (dr["M2_AMOUNT"] != DBNull.Value) this.M2_AMOUNT = Convert.ToInt32(dr["M2_AMOUNT"]);
            if (dr["M3_AMOUNT"] != DBNull.Value) this.M3_AMOUNT = Convert.ToInt32(dr["M3_AMOUNT"]);

            if (dr["M1_TARGET"] != DBNull.Value) this.M1_TARGET = Convert.ToInt32(dr["M1_TARGET"]);
            if (dr["M2_TARGET"] != DBNull.Value) this.M2_TARGET = Convert.ToInt32(dr["M2_TARGET"]);
            if (dr["M3_TARGET"] != DBNull.Value) this.M3_TARGET = Convert.ToInt32(dr["M3_TARGET"]);
            if (dr["TotalQuarterTARGET"] != DBNull.Value) this.TotalQuarterTARGET = Convert.ToInt32(dr["TotalQuarterTARGET"]);
            if (dr["TotalQuarterAMOUNT"] != DBNull.Value) this.TotalQuarterAMOUNT = Convert.ToInt32(dr["TotalQuarterAMOUNT"]);


            if (dr["TotalQuarterAchievement"] != DBNull.Value) this.TotalQuarterAchievement = Convert.ToInt32(dr["TotalQuarterAchievement"]);
            if (dr["PreviousIncentiveAmount"] != DBNull.Value) this.PreviousIncentiveAmount = Convert.ToInt32(dr["PreviousIncentiveAmount"]);
            if (dr["AdjustIncentiveAmount"] != DBNull.Value) this.AdjustIncentiveAmount = Convert.ToInt32(dr["AdjustIncentiveAmount"]);
             this.QuarterlyAchievementThresholds = dr["QuarterlyAchievementThresholds"] as String;
            this.EligibleAsPerConditions = dr["EligibleAsPerConditions"] as String;
            this.COLOR_CHANGE = dr["COLOR_CHANGE"] as String;
            //if (dr["QuarterlyAchievementThresholds"] != DBNull.Value) this. = Convert.ToInt32(dr["QuarterlyAchievementThresholds"]);
            //if (dr["EligibleAsPerConditions"] != DBNull.Value) this.EligibleAsPerConditions = Convert.ToInt32(dr["EligibleAsPerConditions"]);
            if (dr["EligibleIncentiveAmount"] != DBNull.Value) this.EligibleIncentiveAmount = Convert.ToInt32(dr["EligibleIncentiveAmount"]);
            if (dr["IncentiveEntitlement"] != DBNull.Value) this.IncentiveEntitlement = Convert.ToInt32(dr["IncentiveEntitlement"]);
        }
    }
}
