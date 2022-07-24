using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class EventValidationEnt
    {

        public int EventValidationID { get; set; }
        public int EventID { get; set; }
        public int ValidationRuleID { get; set; }
        public string ValidationRuleName { get; set; }


        public EventValidationEnt() { }

        public EventValidationEnt(DataRow dr)
        {

            if (dr["EventValidationID"] != DBNull.Value) { this.EventValidationID = Convert.ToInt32(dr["EventValidationID"]); }
            if (dr["EventID"] != DBNull.Value) { this.EventID = Convert.ToInt32(dr["EventID"]); }
            if (dr["ValidationRuleID"] != DBNull.Value) { this.ValidationRuleID = Convert.ToInt32(dr["ValidationRuleID"]); }
            this.ValidationRuleName = dr["VALIDATIONNAME"] as string;
        }
    }
}
