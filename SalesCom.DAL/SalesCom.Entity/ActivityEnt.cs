using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ActivityEnt
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public int PeriodtypeID { get; set; }
        public int ActivityAmountType { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public ActivityEnt()
        { }
        public ActivityEnt(DataRow dr)
        {
            if (dr["ActivityID"] != DBNull.Value) this.ActivityID = Convert.ToInt32(dr["ActivityID"]);
            this.ActivityName = dr["ActivityName"] as System.String;
            if (dr["PeriodtypeID"] != DBNull.Value) this.PeriodtypeID = Convert.ToInt32(dr["PeriodtypeID"]);
            if (dr["ActivityAmountType"] != DBNull.Value) this.ActivityAmountType = Convert.ToInt32(dr["ActivityAmountType"]);
            if (dr["EffectiveDate"] != DBNull.Value) { this.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]); }
            if (dr["ExpiryDate"] != DBNull.Value) { this.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]); }
        }
    }

    public class Activity2 : ActivityEnt
    {
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }


    public class ActivityWithJoinEnt
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string PeriodTypeName { get; set; }
        public string AmountTypeName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public ActivityWithJoinEnt() { }

        public ActivityWithJoinEnt(DataRow dr)
        {
            if (dr["ActivityId"] != DBNull.Value) { this.ActivityId = Convert.ToInt32(dr["ActivityId"]); }
            this.ActivityName = dr["ActivityName"] as String;
            this.PeriodTypeName = dr["PeriodTypeName"] as String;
            this.AmountTypeName = dr["AmountTypeName"] as String;
            if (dr["EffectiveDate"] != DBNull.Value) { this.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]); }
            if (dr["ExpiryDate"] != DBNull.Value) { this.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]); }
        }

    }

}
