using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ConditionConfigEnt
    {
        public int KPI_CONDITION_CONFIG_ID { get; set; }
        public int KPI_CONFIG_ID { get; set; }
        public int CONDITION_ID { get; set; }

        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }

        public ConditionConfigEnt()
        {}
        public ConditionConfigEnt(DataRow dr)
        {
            if (dr["KPI_CONDITION_CONFIG_ID"] != DBNull.Value) this.KPI_CONDITION_CONFIG_ID = Convert.ToInt32(dr["KPI_CONDITION_CONFIG_ID"]);
            if (dr["KPI_CONFIGURATION_ID"] != DBNull.Value) this.KPI_CONFIG_ID = Convert.ToInt32(dr["KPI_CONFIGURATION_ID"]);
            if (dr["CONDITION_ID"] != DBNull.Value) this.CONDITION_ID = Convert.ToInt32(dr["CONDITION_ID"]);

            if (dr["CREATED_BY"] != DBNull.Value) this.Created_By = Convert.ToInt32(dr["CREATED_BY"]);
            if (dr["CREATED_DATE"] != DBNull.Value) this.Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]);
            if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
        }
    }
}
