using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class SetupProcessEnt
    {
        public int NumId { get; set; }
        public string StrProcessName { get; set; }

        public SetupProcessEnt() { }

        public SetupProcessEnt(DataRow dr)
        {
            if (dr["NUMID"] != DBNull.Value) { this.NumId = Convert.ToInt32(dr["NUMID"]); }
            this.StrProcessName = dr["STRPROCESSNAME"] as String;
        }
    }
}
