using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ConditionEnt
    { 
        public int Condition_id { get; set; }
       // public int Kpi_id { get; set; }
        public string Condition_Name { get; set; }
        public string Procedure_Name { get; set; }
        public int Is_Report_Field { get; set; }
        public int Is_Active { get; set; }
        public string Remarks { get; set; }
        public int Is_Process_Required { get; set; }
        public int Condition_Type { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }

        public ConditionEnt() { }

        public ConditionEnt(DataRow dr)
        {
            if (dr["CONDITION_ID"] != DBNull.Value) { this.Condition_id = Convert.ToInt32(dr["CONDITION_ID"]); }
            this.Condition_Name = dr["CONDITION_NAME"] as String;
            this.Procedure_Name = dr["PROCEDURE_NAME"] as String;
           // if (dr["KPI_ID"] != DBNull.Value) this.Kpi_id = Convert.ToInt32(dr["KPI_ID"]);
            if (dr["IS_REPORT_FIELD"] != DBNull.Value) this.Is_Report_Field = Convert.ToInt32(dr["IS_REPORT_FIELD"]);
            if (dr["IS_ACTIVE"] != DBNull.Value) this.Is_Active = Convert.ToInt32(dr["IS_ACTIVE"]);
            if (dr["REMARKS"] != DBNull.Value) this.Remarks = dr["REMARKS"] as string;
            if (dr["IS_PROCESS_REQUIRED"] != DBNull.Value) this.Is_Process_Required = Convert.ToInt32(dr["IS_PROCESS_REQUIRED"]);
            if (dr["Condition_Type"] != DBNull.Value) this.Condition_Type = Convert.ToInt32(dr["Condition_Type"]);
            if (dr["CREATED_BY"] != DBNull.Value) this.Created_By = Convert.ToInt32(dr["CREATED_BY"]);
            if (dr["CREATED_DATE"] != DBNull.Value) this.Created_Date = Convert.ToDateTime(dr["CREATED_DATE"]);
            if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
        }
    }
}
