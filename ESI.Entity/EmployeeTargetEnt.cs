using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class EmployeeTargetEnt
    {
        public string KPIName { get; set; }
        public int M1 { get; set; }
        public int M2 { get; set; }
        public int M3 { get; set; }
        public int TargetValue { get; set; }
        public int Month { get; set; }
      
        public EmployeeTargetEnt() { }

        public EmployeeTargetEnt(DataRow dr)
        {
            this.KPIName = dr["KPI_NAME"] as String;
            if (dr["TARGET_VALUE"] != DBNull.Value) this.TargetValue = Convert.ToInt32(dr["TARGET_VALUE"]);
            if (dr["MONTH"] != DBNull.Value) this.Month = Convert.ToInt32(dr["MONTH"]);
           
        }
    }
}
