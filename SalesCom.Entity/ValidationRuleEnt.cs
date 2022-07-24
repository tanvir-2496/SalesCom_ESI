using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ValidationRuleEnt
    {
        public int ValidationRuleId { get; set; }
        public string ValidationName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Procedure { get; set; }
        public int IsActive { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string IsDynamic { get; set; }

        public ValidationRuleEnt() { }

        public ValidationRuleEnt(DataRow dr)
        {
            if (dr["VALIDATIONRULEID"] != DBNull.Value) { this.ValidationRuleId = Convert.ToInt32(dr["VALIDATIONRULEID"]); }
            this.ValidationName = dr["VALIDATIONNAME"] as string;
            if (dr["EFFECTIVEDATE"] != DBNull.Value) { this.EffectiveDate = Convert.ToDateTime(dr["EFFECTIVEDATE"]); }
            if (dr["EXPIREDATE"] != DBNull.Value) { this.ExpireDate = Convert.ToDateTime(dr["EXPIREDATE"]); }
            this.Procedure = dr["PROCEDURE"] as String;
            if (dr["ISACTIVE"] != DBNull.Value) { this.IsActive = Convert.ToInt32(dr["ISACTIVE"]); }
            if (dr["ACTIVITYID"] != DBNull.Value) { this.ActivityId = Convert.ToInt32(dr["ACTIVITYID"]); }
            this.ActivityName = dr["ActivityName"] as String;
            this.IsDynamic = dr["IsDynamic"] as String;
        }
    }


    public class ValidationRule2 : ValidationRuleEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
