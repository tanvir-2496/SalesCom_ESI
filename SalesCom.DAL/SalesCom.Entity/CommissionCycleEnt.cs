using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionCycleEnt
    {
        public int CycleId { get; set; }
        public string CycleDescription { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public int CycleStatusId { get; set; }

        public CommissionCycleEnt() { }

        public CommissionCycleEnt(DataRow dr)
        {
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.CycleDescription = dr["CycleDescription"] as String;
            if (dr["PeriodStartDate"] != DBNull.Value) { this.PeriodStartDate = Convert.ToDateTime(dr["PeriodStartDate"]); }
            if (dr["PeriodEndDate"] != DBNull.Value) { this.PeriodEndDate = Convert.ToDateTime(dr["PeriodEndDate"]); }
            if (dr["CycleStatusId"] != DBNull.Value) { this.CycleStatusId = Convert.ToInt32(dr["CycleStatusId"]); }
        }
    }


    public class CommissionCycle2 : CommissionCycleEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }


    public class ReportCycleEnt
    {
        public int CycleId { get; set; }
        public string CycleDescription { get; set; }

        public ReportCycleEnt() { }

        public ReportCycleEnt(DataRow dr)
        {
            if (dr["CycleId"] != DBNull.Value) { this.CycleId = Convert.ToInt32(dr["CycleId"]); }
            this.CycleDescription = dr["CycleDescription"] as String;
        }
    }
}
