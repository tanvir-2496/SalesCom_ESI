using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class TargetListEnt
    {
        public int kpi_id { get; set; }
        public int month { get; set; }
        public string kpi_name { get; set; }
        public string sub_kpi_name { get; set; }
        public double targetValue { get; set; }
        public string status { get; set; }
        //public string SUB_KPI_NAME { get; set; }

        public string unit { get; set; }
        public int head_count { get; set; }
      
        public TargetListEnt()
        {

        }

        public TargetListEnt(DataRow dr)
        {
            if (dr["kpi_id"] != DBNull.Value) { this.kpi_id = Convert.ToInt32(dr["kpi_id"]); }
            if (dr["month"] != DBNull.Value) { this.month = Convert.ToInt32(dr["month"]); }
            this.kpi_name = dr["kpi_name"] as String;
            this.sub_kpi_name = dr["sub_kpi_name"] as String;
            this.unit = dr["unit"] as String;
            this.status = dr["status"] as String;
            if (dr["head_count"] != DBNull.Value) { this.head_count = Convert.ToInt32(dr["head_count"]); }
            if (dr["targetValue"] != DBNull.Value) { this.targetValue = Convert.ToDouble(dr["targetValue"]); }
        }

    }


    public class TargetListEntClone
    {
        public int kpi_id { get; set; }
        public string kpi_name { get; set; }

        public TargetListEntClone()
        {

        }

        public TargetListEntClone(DataRow dr)
        {
            if (dr["kpi_id"] != DBNull.Value) { this.kpi_id = Convert.ToInt32(dr["kpi_id"]); }
            this.kpi_name = dr["kpi_name"] as String;
        }

    }
}
