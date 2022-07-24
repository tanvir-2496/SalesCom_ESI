using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class QuarterMonthCycleEnt
    {
        public int QUARTER_MONTH_CYCLE_ID { get; set; }
        public QuarterMonthCycleEnt() { }

        public QuarterMonthCycleEnt(DataRow dr)
        {
            if (dr["QUARTER_MONTH_CYCLE_ID"] != DBNull.Value) { this.QUARTER_MONTH_CYCLE_ID = Convert.ToInt32(dr["QUARTER_MONTH_CYCLE_ID"]); }

        }
    }
}
