using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class KPICondition
    {
        public int CON_ID { get; set; }
        public string CON_NAME { get; set; }


        public KPICondition() { }

        public KPICondition(DataRow dr)
        {
            if (dr["CON_ID"] != DBNull.Value) { this.CON_ID = Convert.ToInt32(dr["CON_ID"]); }
            this.CON_NAME = dr["CON_NAME"] as String;
        }
    }
}