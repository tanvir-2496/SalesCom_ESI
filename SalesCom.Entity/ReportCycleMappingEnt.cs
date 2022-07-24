using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportCycleMappingEnt
    {
        public int report_cycle_id { get; set; }
        public int report_id { get; set; }
        public string report_name { get; set; }
        public int base_cycle_id { get; set; }
        public string base_cycle { get; set; }
        public int pub_cycle_id { get; set; }
        public string pub_cycle { get; set; }
        public int prov_cycle_id { get; set; }
        public string prov_cycle { get; set; }
        public Int32 status { get; set; }

        public ReportCycleMappingEnt()
        {

        }

        public ReportCycleMappingEnt(DataRow dr)
        {
            if (dr["report_cycle_id"] != DBNull.Value) { this.report_cycle_id = Convert.ToInt32(dr["report_cycle_id"]); }
            if (dr["report_id"] != DBNull.Value) { this.report_id = Convert.ToInt32(dr["report_id"]); }
            this.report_name = dr["report_name"] as String;
            if (dr["base_cycle_id"] != DBNull.Value) { this.base_cycle_id = Convert.ToInt32(dr["base_cycle_id"]); }
            this.base_cycle = dr["base_cycle"] as String;
            if (dr["pub_cycle_id"] != DBNull.Value) { this.pub_cycle_id = Convert.ToInt32(dr["pub_cycle_id"]); }
            this.pub_cycle = dr["pub_cycle"] as String;
            if (dr["prov_cycle_id"] != DBNull.Value) { this.prov_cycle_id = Convert.ToInt32(dr["prov_cycle_id"]); }
            this.prov_cycle = dr["prov_cycle"] as String;
            if (dr["status"] != DBNull.Value) { this.status = Convert.ToInt16(dr["status"]); }
        }
    }
}
