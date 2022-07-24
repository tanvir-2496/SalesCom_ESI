using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class PeriodTypeEnt
    {
        public int PeriodTypeId { get; set; }
        public string PeriodTypeName { get; set; }

        public PeriodTypeEnt() { }

        public PeriodTypeEnt(DataRow dr)
        {
            if (dr["PERIODTYPEID"] != DBNull.Value) { this.PeriodTypeId = Convert.ToInt32(dr["PERIODTYPEID"]); }
            this.PeriodTypeName = dr["PERIODTYPENAME"] as String; 
        }
    }
}
