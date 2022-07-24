using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class RuleGroupEnt
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public RuleGroupEnt() { }

        public RuleGroupEnt(DataRow dr)
        {
            if (dr["GroupID"] != DBNull.Value) { this.GroupID = Convert.ToInt32(dr["GroupID"]); }
            this.GroupName = dr["GroupName"] as string;
        }
    }
}
