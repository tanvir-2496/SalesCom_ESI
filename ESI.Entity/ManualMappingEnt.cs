using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ManualMappingEnt
    {
        public int manualmapcnfg_id { get; set; }
        public int sales_group_id { get; set; }
        public string mapping_name { get; set; }
        public int firstchanneltype { get; set; }
        public int secondchanneltype { get; set; }

        public ManualMappingEnt() { }

        public ManualMappingEnt(DataRow dr)
        {
            if (dr["MANUALMAPCNFG_ID"] != DBNull.Value) { this.manualmapcnfg_id = Convert.ToInt32(dr["MANUALMAPCNFG_ID"]); }
            if (dr["SALES_GROUP_ID"] != DBNull.Value) this.sales_group_id = Convert.ToInt32(dr["SALES_GROUP_ID"]);
            this.mapping_name = dr["MAPPING_NAME"] as String;
            if (dr["FIRSTCHANNELTYPE"] != DBNull.Value) this.firstchanneltype = Convert.ToInt32(dr["FIRSTCHANNELTYPE"]);
            if (dr["SECONDCHANNELTYPE"] != DBNull.Value) this.secondchanneltype = Convert.ToInt32(dr["SECONDCHANNELTYPE"]);
        }
    }
}
