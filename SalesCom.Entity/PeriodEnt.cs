using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class PeriodEnt
    {
        public int PeriodId { get; set; }
        public int PeriodTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Month { get; set; }
        public DateTime PeriodDate { get; set; }
        public string PeriodTypeName { get; set; }
        
        public PeriodEnt() { }

        public PeriodEnt(DataRow dr)
        {
            if (dr["PERIODID"] != DBNull.Value) { this.PeriodId = Convert.ToInt32(dr["PERIODID"]); }
            if (dr["PERIODTYPEID"] != DBNull.Value) { this.PeriodTypeId = Convert.ToInt32(dr["PERIODTYPEID"]); }
            if (dr["STARTDATE"] != DBNull.Value) { this.StartDate = Convert.ToDateTime(dr["STARTDATE"]); }
            if (dr["ENDDATE"] != DBNull.Value) { this.EndDate = Convert.ToDateTime(dr["ENDDATE"]); }
            this.Month = dr["MONTH"] as String;
            if (dr["PERIODDATE"] != DBNull.Value) { this.PeriodDate = Convert.ToDateTime(dr["PERIODDATE"]); }
            this.PeriodTypeName = dr["PeriodTypeName"] as String;
        }

    }
}
