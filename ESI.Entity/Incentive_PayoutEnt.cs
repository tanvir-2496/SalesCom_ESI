using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class Incentive_PayoutEnt
    {
        public int ESI_KPI_INCENTIVE_PAYOUT { get; set; }
        public int REPORT_CYCLE_ID { get; set; }
        public int QUARTER_MONTH_CYCLE_ID { get; set; }
        public int KPI_ID { get; set; }
        public string RELATION_OPARETION { get; set; }
        public int THRESHOLD_PARCENT { get; set; }
        public int EQUEVALENT_PARCENT { get; set; }
        public string IS_AT_ACTUAL { get; set; }
        //public int RatioAmount { get; set; }
        //public string IsLinear { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int CONDITION_ORDER { get; set; }


        public Incentive_PayoutEnt() { }

         public Incentive_PayoutEnt(DataRow dr)
        {
            if (dr["ESI_KPI_INCENTIVE_PAYOUT"] != DBNull.Value) { this.ESI_KPI_INCENTIVE_PAYOUT = Convert.ToInt32(dr["ESI_KPI_INCENTIVE_PAYOUT"]); }
            if (dr["REPORT_CYCLE_ID"] != DBNull.Value) this.REPORT_CYCLE_ID = Convert.ToInt32(dr["REPORT_CYCLE_ID"]);
            if (dr["QUARTER_MONTH_CYCLE_ID"] != DBNull.Value) this.QUARTER_MONTH_CYCLE_ID = Convert.ToInt32(dr["QUARTER_MONTH_CYCLE_ID"]);
            if (dr["KPI_ID"] != DBNull.Value) this.KPI_ID = Convert.ToInt32(dr["KPI_ID"]);
            this.RELATION_OPARETION = dr["RELATION_OPARETION"] as String;
            if (dr["EQUEVALENT_PARCENT"] != DBNull.Value) this.EQUEVALENT_PARCENT = Convert.ToInt32(dr["EQUEVALENT_PARCENT"]);
            if (dr["THRESHOLD_PARCENT"] != DBNull.Value) this.THRESHOLD_PARCENT = Convert.ToInt32(dr["THRESHOLD_PARCENT"]);
            this.IS_AT_ACTUAL = dr["IS_AT_ACTUAL"] as String;
            //if (dr["RatioAmount"] != DBNull.Value) this.RatioAmount = Convert.ToInt32(dr["RatioAmount"]);
            //this.IsLinear = dr["IsLinear"] as String;
            if (dr["CREATE_DATE"] != DBNull.Value) this.CREATE_DATE = Convert.ToDateTime(dr["CREATE_DATE"]);
            if (dr["CONDITION_ORDER"] != DBNull.Value) this.CONDITION_ORDER = Convert.ToInt32(dr["CONDITION_ORDER"]);
        }
    }
}
