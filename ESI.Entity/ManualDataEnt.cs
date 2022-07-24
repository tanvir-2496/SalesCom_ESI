using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ManualDataEnt
    {
        public int manualdatacnfg_id { get; set; }
        public int sales_group_id { get; set; }
        public string data_name { get; set; }
        public int erownum { get; set; }

        public ManualDataEnt() { }

        public ManualDataEnt(DataRow dr)
        {
            if (dr["MANUALDATACNFG_ID"] != DBNull.Value) { this.manualdatacnfg_id = Convert.ToInt32(dr["MANUALDATACNFG_ID"]); }
            if (dr["SALES_GROUP_ID"] != DBNull.Value) this.sales_group_id = Convert.ToInt32(dr["SALES_GROUP_ID"]);
            this.data_name = dr["DATA_NAME"] as String;
            if (dr["EROWNUM"] != DBNull.Value) this.erownum = Convert.ToInt32(dr["EROWNUM"]);
        }
    }
}
